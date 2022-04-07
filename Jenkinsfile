pipeline {
    agent any
    triggers {
        pollSCM("*/5 * * * *")
    }
    environment {
        COMMITMSG = sh(returnStdout: true, script: "git log -1 --oneline")
    }
    stages {
        stage("Startup") {
            steps {
                buildDescription env.COMMITMSG
            }
            
        }
        
        stage("Build") {
            parallel{

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
                        dir("IRateYou2-Frontend")
                            sh "ng serve"
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
            withCredentials([string(credentialsId: 'DiscordWebhookURL', variable: 'WEBHOOK_URL')]) {
            sh "echo 'The pipeline has finished!'"
            discordSend description: "Jenkins Pipeline Build", footer: "Gruppe A2", link: "https://www.youtube.com/watch?v=dQw4w9WgXcQ&ab_channel=RickAstley", image: "https://i.imgur.com/jWr67J8.png", result: currentBuild.currentResult, title: JOB_NAME, webhookURL: "${WEBHOOK_URL}"
            }
        }
    }
  
}
