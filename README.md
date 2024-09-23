
# SendGridClient

This repository contains a .NET 8 library for sending emails using the SendGrid API. The client includes a retry mechanism to handle transient failures and ensures reliable email delivery.

## Table of Contents

1. [Introduction](#introduction)
2. [Features](#features)
3. [Tech Stack](#tech-stack)
5. [Usage](#usage)
6. [Configuration](#configuration)

## Introduction

The SendGrid Client is designed to integrate with .NET applications, providing a robust solution for sending emails via the SendGrid API. The implementation includes a retry mechanism to handle network failures or temporary issues with the SendGrid service.

## Features

- **Send Emails:** Send emails with plain text or HTML content.
- **Retry Mechanism:** Automatically retries failed requests with exponential backoff.

## Tech Stack

- **Backend:** .NET 8
- **Email Sending:** SendGrid API
- **HTTP Client:** RestSharp
- **Dependency Injection:** Used for service registrations and configurations

## Usage

1. **Register the SendGridClient:** Use the `RegisterSendGridClient` method in `DepInj` to register the client in the dependency injection container.
2. **Send Emails:** Use the `SendEmailAsync` method from the `ISendGridClient` to send emails with a retry mechanism.

## Configuration

### SendGridOptions

- **ApiKey:** The API key for SendGrid.

```csharp
public class SendGridOptions
{
    public string ApiKey { get; set; }
}
```
