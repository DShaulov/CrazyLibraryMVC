INSERT INTO customers (
    Passport,
    FirstName,
    LastName,
    Address,
    City,
    Email,
    PhoneNumber,
    Zip,
    BirthDate
)
VALUES (
    @Passport,
    @FirstName,
    @LastName,
    @Address,
    @City,
    @Email,
    @PhoneNumber,
    @Zip,
    @BirthDate
);