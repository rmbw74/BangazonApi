
INSERT INTO Orders
SELECT null, c.Id, p.Id, "01/25/2018"
FROM Customer c, Payment p WHERE c.FirstName = 'Brian' and p.AccountNumber = 6767858594940303;

INSERT INTO Orders
SELECT null, c.Id, p.Id, "01/24/2018"
FROM Customer c, Payment p WHERE c.FirstName = 'Abbye';

INSERT INTO Orders
SELECT null, c.Id, p.Id, "01/23/2018"
FROM Customer c, Payment p WHERE c.FirstName = 'Terry' and p.AccountNumber = 9098765434526178;