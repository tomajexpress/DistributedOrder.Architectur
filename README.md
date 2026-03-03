# DistributedOrder.Architectur 🚀
[![.NET](https://img.shields.io/badge/.NET-10.0-purple.svg)](https://dotnet.microsoft.com/)
[![Architecture](https://img.shields.io/badge/Architecture-Clean%20%26%20DDD-green.svg)](https://medium.com/@aman.toumaj/mastering-domain-driven-design-a-tactical-ddd-implementation-5255d71d609f)
[![License](https://img.shields.io/badge/License-MIT-blue.svg)](LICENSE)

This repository showcases a modern, distributed microservices architecture built with .NET 9/10, Blazor WebAssembly, and IdentityServer. It demonstrates the implementation of centralized authentication and intelligent API routing in a scalable enterprise environment.

## 📖 Overview
The system consists of four primary components designed to work seamlessly in a secured network environment:

1.  **IdentityServer (IdP):** Powered by Duende IdentityServer. It manages user identities (OIDC) and issues secure JWT tokens.

2.  **Ocelot API Gateway:** The central entry point for the frontend. Handles request routing and security offloading (token validation).

3.  **Order.API:** A specialized microservice for order management, protected by fine-grained, policy-based authorization.

4.  **Blazor WebUI:** A modern WebAssembly frontend utilizing a CustomAuthorizationMessageHandler to automatically attach tokens to outgoing API requests.

## 🛠️ Tech Stack

* **Frontend:** Blazor WebAssembly (WASM)
* **Gateway:** Ocelot API Gateway
* **Security:** OpenID Connect (OIDC), OAuth2, JWT Bearer Tokens
* **Backend:** ASP.NET Core Web API
* **Auth Provider:** Duende IdentityServer

## 🚀 Getting Started
To run this project locally, the components must be started in a specific order to ensure discovery endpoints and security handshakes are available.

Prerequisites

✅  .NET 9.0 SDK (or later)

✅  Visual Studio 2022 / JetBrains Rider / VS Code

## Installation & Startup
1.  **Clone the repository:**
     ```bash
     git clone https://github.com/YOUR-USERNAME/DistributedOrder.Architecture.git
     cd DistributedOrder.Architecture

2.  **Startup Order (Crucial):**

Run the projects in the following order to avoid port conflicts and authentication handshake failures:

| Project | Port | Description |
| :--- | :--- | :--- |
| **IdentityServer.Host** | 7234 | The Identity Provider (IdP) | 
| **Order.API** | 7079 | The Business Logic Microservice |
| **ApiGateway.Ocelot** | 7135 | The Gateway (Main Entry Point) |
| **Web.BlazorClient** | 7003 | The User Interface |

3.  **Test Credentials:**
     *  User: alice | Password: alice (Role: SeniorDeveloper)       
     *  User: bob | Password: bob (Role: User)

## 🔐 Key Security Features
* **Centralized SSO:** Single Sign-On experience across the entire microservice landscape.
* **Token-Based Communication:** Secure identity exchange using JSON Web Tokens (JWT).
* **Policy-Based Authorization:** Granular access control (e.g., only the SeniorDeveloper role can delete orders).
* **CORS Management:** Secure Cross-Origin Resource Sharing between the WASM client and the Gateway.

## 💡 Lessons Learned
* Implementing the **BFF (Backend-for-Frontend)** pattern using Ocelot.
* Configuring **OIDC flows** in a distributed development environment.
* Mastering **DelegatingHandlers** in Blazor for seamless token injection.
* Advanced debugging of network scenarios including CORS, Path-Matching, and 401/404 errors.

## 🤝 Contributing
Contributions are welcome! Please ensure that any PR maintains the "Green" status of the Architecture Tests.

## ✍️ Author
Aman Toumaj Senior Software Developer & Architecture Enthusiast

[![Medium](https://img.shields.io/badge/Medium-12100E?style=for-the-badge&logo=medium&logoColor=white)](https://medium.com/@aman.toumaj)
