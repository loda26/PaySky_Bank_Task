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

1. [Account Management]
   - Supports two account types:
     - CheckingAccount (allows overdraft up to a limit).
     - SavingsAccount (no overdraft, balance must stay positive).
   - CRUD operations for accounts.

2. [Transactions]
   - Records deposits, withdrawals, and transfers in a transaction log.
   - Includes transaction details such as type, amount, and timestamp.

3. [Endpoints]
   - Create, deposit, withdraw, transfer, and retrieve balance.

4. [Database]
   - Tables for Accounts, AccountTypes, Transactions, and TransactionTypes.

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
        "accountNumber": "123456789",
        "amount": 200.0
    }
    ```

- **POST** `/api/accounts/withdraw`
  - Withdraw funds from an account.
  - **Request Body**:
    ```json
    {
        "accountNumber": "123456789",
        "amount": 150.0
    }
    ```

- **POST** `/api/accounts/transfer`
  - Transfer funds between accounts.
  - **Request Body**:
    ```json
    {
        "sourceAccountNumber": "123456789",
        "targetAccountNumber": "987654321",
        "amount": 100.0
    }
    ```

---

## Database Schema

- **Accounts**: Stores account details such as account number, balance, and account type.
- **AccountTypes**: Lookup table for account types (e.g., Checking, Savings).
- **Transactions**: Logs all transactions (deposit, withdraw, transfer).
- **TransactionTypes**: Lookup table for transaction types (e.g., Deposit, Withdraw, Transfer).

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
│   └── Migrations
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

## How to Run

1. Clone the repository:
   ```bash
   git clone https://github.com/yourusername/BankingSystemAPI.git
   ```

2. Navigate to the project directory:
   ```bash
   cd BankingSystemAPI
   ```

3. Set up the database:
   - Update the connection string in `appsettings.json`.
   - Apply migrations:
     ```bash
     dotnet ef database update
     ```

4. Run the application:
   ```bash
   dotnet run
   ```

5. Access the Swagger UI for API testing:
   - Navigate to `http://localhost:<port>/swagger`.

---

## Technologies Used
- ASP.NET Core
- Entity Framework Core
- SQL Server
- Swagger for API documentation

---

## Future Enhancements
- Add support for recurring transactions.
- Include account holder details and authentication.
- Implement unit tests for business logic.

---

## License

This project is licensed under the [MIT License](LICENSE).

---

## Contact

For questions or suggestions, feel free to contact me at [your.email@example.com].
