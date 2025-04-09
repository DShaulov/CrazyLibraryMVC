SELECT AuthorId
FROM authors
WHERE FirstName = @FirstName
  AND LastName = @LastName
  AND BirthDate = @BirthDate;