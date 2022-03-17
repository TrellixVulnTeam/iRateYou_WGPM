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
                    publishCoverage adapters: [coberturaAdapter('IRateYou2-Backend/IRateYou2.Core.Test/TestResults/*/coverage.cobertura.xml')]
                }
            }

        }
    }
  
}
