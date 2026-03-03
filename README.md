# DistributedOrder.Architectur 🚀
[![.NET](https://img.shields.io/badge/.NET-10.0-purple.svg)](https://dotnet.microsoft.com/)
[![License](https://img.shields.io/badge/License-MIT-blue.svg)](LICENSE)

This repository showcases a modern, distributed microservices architecture built with .NET 9/10, Blazor WebAssembly, and IdentityServer. It demonstrates the implementation of centralized authentication and intelligent API routing in a scalable enterprise environment.

## 📖 Overview
The system consists of four primary components designed to work seamlessly in a secured network environment:

1.  **IdentityServer (IdP):** Powered by Duende IdentityServer. It manages user identities (OIDC) and issues secure JWT tokens.

2.  **Ocelot API Gateway:** The central entry point for the frontend. Handles request routing and security offloading (token validation).

3.  **Order.API:** A specialized microservice for order management, protected by fine-grained, policy-based authorization.

4.  **Blazor WebUI:** A modern WebAssembly frontend utilizing a CustomAuthorizationMessageHandler to automatically attach tokens to outgoing API requests.

## 🛠 Tech Stack
1.  **Frontend:** Blazor WebAssembly (WASM)
2.  **Gateway:** Ocelot API Gateway
3.  **Security:** OpenID Connect (OIDC), OAuth2, JWT Bearer Tokens
4.  **Backend:** ASP.NET Core Web API
5.  **Auth Provider:** Duende IdentityServer
