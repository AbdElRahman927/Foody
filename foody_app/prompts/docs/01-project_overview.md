# Foody

## Project Overview

Foody is a modern Full-Stack Restaurant Discovery and Review Platform designed to help customers discover restaurants, explore detailed restaurant information, read reviews, share their dining experiences, and interact with restaurant-related services.

The platform is designed as a production-inspired learning project that demonstrates real-world software development practices across mobile, backend, database, and web technologies.

The overall Foody platform consists of:

* Flutter mobile application for customers.
* ASP.NET Core Web API backend.
* SQL Server database.
* React-based Restaurant Owner Dashboard.
* React-based Admin Dashboard.

This repository contains the **Flutter mobile application only**. The backend, database, and web dashboards are maintained as separate projects while following the same overall business requirements.

---

# Vision

Create a simple, modern, and user-friendly restaurant platform that helps customers discover restaurants with confidence while providing restaurant owners with a structured way to manage their restaurant information.

Foody prioritizes a clear and enjoyable user experience over unnecessary complexity or excessive features.

---

# Project Goals

The main goals of the project are to:

* Build a complete Full-Stack application using modern technologies.
* Practice real-world software architecture and project organization.
* Develop a maintainable Flutter mobile application.
* Build a RESTful backend using ASP.NET Core.
* Design and work with a relational SQL Server database.
* Apply reusable UI and component-based development principles.
* Maintain a clean and scalable codebase.
* Practice proper Git and collaborative development workflows.
* Gain practical experience integrating a mobile application with a backend API.

---

# Target Users

## Customer

The primary user of the Foody mobile application.

Customers can:

* Create and manage an account.
* Discover restaurants.
* Search for restaurants.
* Browse restaurant categories.
* View restaurant details.
* Read reviews.
* Write reviews.
* Rate restaurants.
* Save favorite restaurants.
* Access restaurant-related external links.

The mobile application is designed primarily for customers.

---

## Restaurant Owner

Restaurant owners use the Restaurant Owner Web Dashboard.

They can:

* Register a restaurant.
* Manage restaurant information.
* Manage menu information.
* Upload and manage restaurant images.
* Manage external links.
* Update business information.

Restaurant registration requires administrator review and approval before the restaurant becomes publicly visible on the platform.

---

## Administrator

Administrators use a separate Admin Web Dashboard.

They can:

* Review restaurant registration requests.
* Approve or reject restaurants.
* Monitor platform activity.
* Manage users.
* Moderate platform content when necessary.

---

# Platform Structure

| Platform                   | Technology           | Primary Users        |
| -------------------------- | -------------------- | -------------------- |
| Mobile Application         | Flutter              | Customers            |
| Backend API                | ASP.NET Core Web API | All platform clients |
| Database                   | SQL Server           | Backend              |
| Restaurant Owner Dashboard | React                | Restaurant Owners    |
| Admin Dashboard            | React                | Administrators       |

---

# Core Product Features

The overall Foody product scope includes the following feature areas.

## Authentication & User Profile

* Registration
* Login
* Email Verification
* Forgot Password
* User Profile
* Complete Profile

## Restaurant Discovery

* Homepage
* Restaurant Categories
* Restaurant Search
* Restaurant Discovery
* Restaurant Suggestions

## Restaurant Details

* Restaurant information
* Business information
* Restaurant images
* Menu information
* External links
* Social media links
* Ordering platform links

## Reviews & Ratings

* View reviews
* Create reviews
* Edit reviews
* Rate restaurants

## Favorites

* Save restaurants
* Remove restaurants from favorites

## Restaurant Owner Management

* Restaurant registration
* Restaurant information management
* Menu management
* Image management
* External links management

## Administration

* Restaurant approval
* User management
* Platform monitoring
* Content moderation

The features listed in this section describe the **overall product scope** and do not represent the implementation scope of the current development phase.

The active implementation scope is defined exclusively in:

`docs/06_current_phase.md`

---

# Business Model & Platform Concept

Foody is designed around three primary platform participants:

```text
Customer
   ↓
Discovers Restaurants
   ↓
Views Restaurant Information
   ↓
Reads / Creates Reviews
   ↓
Shares Dining Experience


Restaurant Owner
   ↓
Registers Restaurant
   ↓
Administrator Review
   ↓
Restaurant Approval
   ↓
Manages Restaurant Information


Administrator
   ↓
Reviews Platform Activity
   ↓
Approves Restaurants
   ↓
Manages Users
   ↓
Moderates Content
```

The platform is designed to create a structured relationship between customers, restaurant owners, and administrators.

---

# Technology Stack

| Layer              | Technology           |
| ------------------ | -------------------- |
| Mobile Application | Flutter              |
| Backend            | ASP.NET Core Web API |
| Database           | SQL Server           |
| Web Dashboards     | React                |
| UI/UX Design       | Figma                |
| Version Control    | Git & GitHub         |

Additional libraries, packages, and implementation technologies may be introduced during development when justified and approved according to the project's development rules.

---

# Mobile Application Scope

The Flutter application is the customer-facing part of Foody.

Its responsibilities include:

* Authentication.
* User profile management.
* Restaurant discovery.
* Restaurant browsing.
* Restaurant details.
* Reviews and ratings.
* Favorites.
* Restaurant-related external links.
* User-facing feedback and interaction.

Restaurant Owner and Administrator functionality is handled through separate web dashboards and is not implemented inside the customer mobile application unless explicitly defined otherwise in the project requirements.

---

# Version 1 Scope

Version 1 focuses on the core restaurant discovery and review experience.

The following capabilities are intentionally excluded from the initial version:

* Dark Mode.
* Push Notifications.
* AI-based Restaurant Recommendation.
* Offline Mode.
* Multi-language Support.
* Payment Integration.
* Live Chat.
* Loyalty Programs.

These features may be reconsidered in future versions.

Excluding a feature from Version 1 does not permanently prevent it from being implemented later.

---

# Development Philosophy

Foody follows a feature-based development approach.

Features are designed, implemented, tested, and refined individually while respecting the overall project architecture and Design System.

The project prioritizes:

* Maintainability.
* Readability.
* Reusability.
* Simplicity.
* Scalability.
* Consistent UI/UX.
* Clear separation of responsibilities.

The goal is not to build the largest possible application, but to build a clean, well-organized, production-inspired system.

---

# Project Principles

1. The mobile application is customer-focused.
2. Restaurant Owners use the Restaurant Owner Web Dashboard.
3. Administrators use a separate Admin Web Dashboard.
4. The backend provides the central API layer for platform clients.
5. Features are implemented phase by phase.
6. The current phase defines the active implementation scope.
7. Project-wide decisions are documented separately.
8. UI consistency is maintained through the Foody Design System.
9. Existing components and patterns should be reused whenever appropriate.
10. New technologies or architectural patterns should be introduced only when they provide meaningful value.

---

# Documentation Context

This document defines the **high-level identity, purpose, scope, and goals of Foody**.

Technical architecture is documented in:

`docs/02_architecture.md`

UI and visual rules are documented in:

`docs/03_design_system.md`

Reusable components are documented in:

`docs/04_components.md`

Coding standards are documented in:

`docs/05_coding_guidelines.md`

The active development phase is documented in:

`docs/06_current_phase.md`

Future development phases are documented in:

`docs/07_future_phases.md`

Important project decisions are documented in:

`docs/08_decisions.md`

AI Agent behavior and workflow are documented separately inside:

`agents/`

---

# AI Agent Context

AI Agents should use this document to understand the overall Foody product and its boundaries.

This document should not be treated as the source of detailed implementation instructions.

For implementation behavior, Agents must follow the relevant project documentation and the rules defined inside the `agents/` directory.

The Agent must always consider the distinction between:

* Overall Foody product scope.
* Current development phase scope.
* Future development scope.

A feature being listed in this document does not mean that it should be implemented immediately.
