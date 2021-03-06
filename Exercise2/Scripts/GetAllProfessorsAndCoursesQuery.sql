SELECT DISTINCT P.[NAME] AS [PROFESSOR_NAME], C.[NAME] AS [COURSE_NAME]
FROM [dbo].[PROFESSOR] P
INNER JOIN [dbo].[DEPARTMENT] D
ON P.DEPARTMENT_ID = D.ID
INNER JOIN [dbo].[COURSE] C
ON C.DEPARTMENT_ID = D.ID
INNER JOIN [dbo].[SCHEDULE] S
ON S.PROFESSOR_ID = P.ID 
AND S.COURSE_ID = C.ID
ORDER BY P.[NAME], C.[NAME]