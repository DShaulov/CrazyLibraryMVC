INSERT INTO books (
    Id,
    Title,
    Description,
    AuthorId,
    PublicationDate,
    Image_url,
    LibraryCallNumber,
    TotalCopies,
    CopiesAvailable,
    BorrowCount
)
VALUES (
    @Id,
    @Title,
    @Description,
    @AuthorId,
    @PublicationDate,
    @Image_url,
    @LibraryCallNumber,
    @TotalCopies,
    @CopiesAvailable,
    @BorrowCount
);