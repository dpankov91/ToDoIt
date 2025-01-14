pipeline {
    agent any
    triggers {
	    cron("0 * * * *")
		pollSCM("*/5 * * * *")
	}
    stages {
        stage("Build Web") {
            steps {
                //echo "===== OPTIONAL: Will build the website (if needed) ====="
                sh "dotnet build src/Todoit.sln"
            }
        }
        stage("Build API") {
            steps {
               // echo "===== REQUIRED: Will build the API project ====="
               sh "dotnet build src/RestAPI/RestAPI.csproj"
            }
        }
        stage("Test API") {
            steps {
                // echo "===== REQUIRED: Will execute unit tests of the API project ====="
                sh "dotnet test src/TestProject/TestProject.csproj"
            }
        }
        stage("Deliver API") {
            steps {
                // echo "===== REQUIRED: Will deliver API to Docker Hub ====="
                sh "docker build src/. -t dpankov91/todoapi -f src/RestAPI/Dockerfile"
                withCredentials([[$class: 'UsernamePasswordMultiBinding', credentialsId: 'DockerHub', usernameVariable: 'USERNAME', passwordVariable: 'PASSWORD']])
                {
                    sh 'docker login -u ${USERNAME} -p ${PASSWORD}'
                }   
                sh "docker push dpankov91/todoapi"
            }
        }
        stage("Deliver Web") {
            steps {
                echo "===== REQUIRED: Will deliver the Web to Docker Hub ====="
                /*sh "docker build src/. -t dpankov91/todoweb -f ToDoIt-Frontend/Dockerfile"
                withCredentials([[$class: 'UsernamePasswordMultiBinding', credentialsId: 'DockerHub', usernameVariable: 'USERNAME', passwordVariable: 'PASSWORD']])
                {
                    sh 'docker login -u ${USERNAME} -p ${PASSWORD}'
                }
                sh "docker push dpankov91/todoweb"*/
            }
        }
        stage("Release staging environment") {
            steps {
                // echo "===== REQUIRED: Will use Docker Compose to spin up a test environment ====="
                sh "docker-compose pull"
                sh "docker-compose up -d --build"
            }
        }
        stage("Automated acceptance test") {
            steps {
                echo "===== REQUIRED: Will use Selenium to execute automatic acceptance tests ====="
            }
        }
    }
}