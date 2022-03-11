pipeline {
    agent none
    stages {
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
                    }
                }
            }
        }
        stage("Test"){
            steps{
                sh "tests run"
            }
        }
    }
}
