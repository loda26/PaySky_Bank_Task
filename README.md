# Banking System API

A simple banking system API built using ASP.NET Core to manage accounts and transactions, with support for:
- Creating accounts
- Depositing funds
- Withdrawing funds
- Transferring funds
- Retrieving account balances

The application uses Entity Framework Core for database persistence and follows RESTful API principles.

---

## Features

1. **Account Management**
   - Supports two account types:
     - CheckingAccount (allows overdraft up to a limit).
     - SavingsAccount (no overdraft, balance must stay positive).
   - CRUD operations for accounts.

2. **Transactions**
   - Records deposits, withdrawals, and transfers in a transaction log.
   - Includes transaction details such as type, amount, and timestamp.

3. **Endpoints**
   - Create, deposit, withdraw, transfer, and retrieve balance.

4. **Database**
   - Tables for Accounts, AccountTypes, Transactions, and TransactionTypes.

---

## Technologies Used
- ASP.NET Core
- Entity Framework Core
- SQL Server
- Swagger for API documentation

---

## Project Structure

```
BankingSystemAPI
├── Controllers
│   └── AccountsController.cs
├── Services
│   ├── IAccountService.cs
│   └── AccountService.cs
├── Data
│   ├── BankingDbContext.cs
├── Models
│   ├── Account.cs
│   ├── AccountType.cs
│   ├── Transaction.cs
│   ├── TransactionType.cs
│   ├── DTOs
│   │   ├── CreateAccountRequest.cs
│   │   ├── DepositRequest.cs
│   │   ├── WithdrawRequest.cs
│   │   └── TransferRequest.cs
├── appsettings.json
└── Program.cs
```

---

## Database Schema

- **Accounts**: Stores account details such as account number, balance, and account type.
- **AccountTypes**: Lookup table for account types (e.g., Checking, Savings).
- **Transactions**: Logs all transactions (deposit, withdraw, transfer).
- **TransactionTypes**: Lookup table for transaction types (e.g., Deposit, Withdraw, Transfer).

---

## How to Run

- Set up the database:
   - Update the connection string in `appsettings.json`.
   - Open Tools -> NuGetPackageManager -> Package Manager Console.
   - Apply migrations:
     ```bash
     add-migration bank
     ```
  - Update Database:
     ```bash
     update-database
     ```
---

## Endpoints

### Account Endpoints
- **POST** `/api/accounts/create`
  - Create a new account.
  - **Request Body**:
    ```json
    {
        "accountNumber": "123",
        "initialBalance": 500,
        "accountTypeId": 1
    }
    ```
    - **Request Body**:
    ```json
    {
        "accountNumber": "321",
        "initialBalance": 1000,
        "accountTypeId": 2
    }
    ```

- **GET** `/api/accounts`
  - Retrieve all accounts.

- **GET** `/api/accounts/{accountNumber}/balance`
  - Get the balance of a specific account.

### Transaction Endpoints
- **POST** `/api/accounts/deposit`
  - Deposit funds into an account.
  - **Request Body**:
    ```json
    {
        "accountNumber": "123",
        "amount": 200.0
    }
    ```

- **POST** `/api/accounts/withdraw`
  - Withdraw funds from an account.
  - **Request Body**:
    ```json
    {
        "accountNumber": "123",
        "amount": 150.0
    }
    ```

- **POST** `/api/accounts/transfer`
  - Transfer funds between accounts.
  - **Request Body**:
    ```json
    {
        "sourceAccountNumber": "123",
        "targetAccountNumber": "321",
        "amount": 100.0
    }
    ```

---

## Contact

For questions or suggestions, feel free to contact me at [mokhaled26498@gmail.com].
