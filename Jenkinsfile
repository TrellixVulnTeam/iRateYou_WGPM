pipeline {
    agent any
    triggers {
        pollSCM("*/5 * * * *")
    }
    environment {
        COMITMSG = sh(returnStdout: true, script: "git log -1 --oneline")
    }
    stages {
        stage("Startup") {
            steps {
                buildDescription env.COMMITMSG
            }
        }
        
        stage("Build") {
            parallel{
                stage("Coverage Adapter"){
                    steps{
                        publishCoverage adapters: [jacocoAdapter('target/site/jacoco/jacoco.xml')]
                    }
                }
                stage("Build api"){
                    steps {
                        echo "echo 'We are building the API'"
                        dir("IRateYou2-Backend/IRateYou2.WebAPI"){
                            sh "dotnet build" 
                        }
                    }
                }
                stage("Build Frontend"){
                    steps{
                        sh "echo 'We are building the frontend'"
                    }
                }
            }
        }
        stage("Test"){
            steps{
                  dir("IRateYou2-Backend/IRateYou2.Core.Test"){
                      sh "dotnet add package coverlet.collector"
                      sh "dotnet test --collect:'XPlat Code Coverage'" 
                  }
            }
            post {
                success {
                    archiveArtifacts "IRateYou2-Backend/IRateYou2.Core.Test/TestResults/*/coverage.cobertura.xml"
                    publishCoverage adapters: [coberturaAdapter(path: 'IRateYou2-Backend/IRateYou2.Core.Test/TestResults/*/coverage.cobertura.xml',
                     thresholds: [[failUnhealthy: true, thresholdTarget: 'Conditional', unhealthyThreshold: 10.0, unstableThreshold: 1.0]])], sourceFileResolver: sourceFiles('NEVER_STORE')
                }
            }

        }
    }
    post {
        always {
            sh "echo 'The pipeline has finished!'"
            discordSend description: "Jenkins Pipeline Build", footer: "Footer Text", link: env.BUILD_URL, result: currentBuild.currentResult, title: JOB_NAME, webhookURL: 'https://discord.com/api/webhooks/954004988013707334/-YGVFR1tMHesJqAWoPDf1oR-9f81WPC7CmL48L-60yh5dMNMUCs6D6DTm-gRe2SZJ_Pw'
        }
    }
  
}
