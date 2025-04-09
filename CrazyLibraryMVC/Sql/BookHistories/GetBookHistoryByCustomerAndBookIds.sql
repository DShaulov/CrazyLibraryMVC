SELECT *
FROM bookhistories
WHERE BookId = @BookId
  AND CustomerId = @CustomerId
  AND ReturnDate IS null;
