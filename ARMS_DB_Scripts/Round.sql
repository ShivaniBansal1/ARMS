 IF OBJECT_ID('ARMS.Round') IS NULL
BEGIN
CREATE TABLE ARMS.Round(
id int identity(1,1) primary key,
roundTypeId int NOT NULL,
constraint FK_roundType foreign key(roundTypeId) references ARMS.RoundType(id),
interviewId int NOT NULL,
createdAt datetime2  default (sysdatetime()) NOT NULL,
constraint FK_Interview foreign key(interviewId) references ARMS.Interview(id),
modifiedAt datetime2  default (sysdatetime()) NOT NULL,
createdBy varchar(50) NULL,
modifiedBy varchar(50) NULL
)
END

--creating the trigger for any update of interview
--new batch for trigger
GO
CREATE TRIGGER trg_UpdateRound
ON ARMS.Round
AFTER UPDATE
AS
    UPDATE ARMS.Round
    SET modifiedAt  = sysdatetime()
    WHERE id IN (SELECT DISTINCT id FROM Inserted)

GO 
--insert command

Insert into ARMS.Round(roundTypeId,interviewId)
Values('2','1')

--Select command
select * FROM ARMS.Round
--Select command with joins
select *FROM ARMS.Round INNER JOIN ARMS.Interview  on ARMS.Round.interviewId=ARMS.interview.id INNER JOIN ARMS.RoundType on ARMS.Round.roundTypeId =ARMS.RoundType.id