INSERT INTO bookhistories (
    BookId,
    CustomerId,
    BorrowDate,
    ReturnDate
)
VALUES (
    @BookId,
    @CustomerId,
    @BorrowDate,
    @ReturnDate
);