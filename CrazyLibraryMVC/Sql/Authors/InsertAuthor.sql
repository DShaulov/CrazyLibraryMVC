INSERT INTO authors (
    FirstName,
    LastName,
    BirthDate
)
VALUES (
    @FirstName,
    @LastName,
    @BirthDate
);
SELECT LAST_INSERT_ID();