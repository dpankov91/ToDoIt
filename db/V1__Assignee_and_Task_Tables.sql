CREATE TABLE Assignee(
	Id INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	Name VARCHAR(75) NOT NULL
)

CREATE TABLE Task(
	Id INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	Description VARCHAR(255) NOT NULL,
    AssigneeId INT NULL,
    DueDate DATE NOT NULL,
    IsCompleted BIT NOT NULL
)