# QuickEnrol – DfE Tech Interview Prep Project

**QuickEnrol** is a mobile-first Blazor app that simulates a GOV.UK-style course enrolment service. It demonstrates key skills from the DfE job description within a realistic 10–12 hour build window.

---

## 🧩 Project Overview

| Feature | Description |
|---------|-------------|
| 🔐 Sign-in | Azure AD OIDC login via Entra ID Dev tenant |
| 🎓 Courses | View courses from static JSON (or Contentful) |
| ✅ Enrolment | Click “Enrol” to trigger async event via NServiceBus |
| 🧠 Storage | SQLite (relational), future swap to SQL Server |
| 🔄 Event Handling | NServiceBus handler writes enrolment record |
| 🔧 CI/CD | GitHub Actions: build, test, Docker image |
| 🌐 Accessibility | WCAG‑compliant layout using GOV.UK styles |

---

## 📦 Architecture

```
[Browser] ──► Blazor WASM (Bootstrap 5, GOV.UK palette)
     ▲          │     ▲
     │          │     └── (1) OIDC sign‑in via Azure AD dev tenant
     │          │
     │      (2) HTTPS /api/courses      (3) HTTPS /api/enrol
     │          │                            │
     ▼          ▼                            ▼
┌────────────────────────┐        ┌────────────────────┐
│  ASP.NET Core Minimal   │        │ NServiceBus Worker │
│  API "Gateway"          │──► SB  │ (LearningTransport)│
│  * SQLite DB            │  Msg   └────────────────────┘
└────────────────────────┘
        │
        └── GitHub Actions CI (build, test, container)
```

---

## ✅ JD Requirements Mapping

| JD Ref | Covered By |
|--------|------------|
| a) ASP.NET sites | `QuickEnrol.Api` (Minimal API) |
| b) Composite UI | Blazor WASM client |
| c) Identity/OAuth | Azure AD login using OIDC |
| d) Storage | SQLite + EF Core |
| e) Event‑driven | NServiceBus + LearningTransport |
| f) C#/HTML/CSS | Blazor frontend + Bootstrap |
| g) TDD & CI/CD | xUnit tests + GitHub Actions |
| h) GDS/standards | GOV.UK styles, open repo, WCAG audit |
| i) REST APIs | `/api/courses`, `/api/enrol` |
| j) Mobile-first | Bootstrap grid layout |
| k) Security | HTTPS enforced + accessibility checks |

---

## 📁 Repo Structure

```
/QuickEnrol
 ├─ src/
 │   ├─ QuickEnrol.Client/        (Blazor WASM)
 │   ├─ QuickEnrol.Api/           (Minimal API)
 │   └─ QuickEnrol.EnrolHandler/  (NServiceBus Worker)
 ├─ tests/
 │   └─ QuickEnrol.Tests/         (xUnit tests)
 ├─ .github/workflows/ci.yml      (CI pipeline)
 ├─ docs/architecture.png         (Diagram)
 └─ README.md
```

---

## 🛠️ Technologies Used

- **.NET 8 / ASP.NET Core / Blazor WASM**
- **Azure AD OIDC** (Single-tenant login via Entra Dev)
- **NServiceBus** with `LearningTransport`
- **SQLite** via EF Core
- **Bootstrap 5 + GOV.UK colour palette**
- **GitHub Actions** CI/CD

---

## ⏱️ 10-Hour Build Plan

| Slot | Duration | What you will do | Outcome |
|------|----------|------------------|---------|
| **Mon Evening** | 2 h | Scaffold Blazor shell, GOV.UK palette, layout | Front‑end shell |
| **Tue Evening** | 2 h | Azure AD tenant + sign-in + `[Authorize]` | Secure client |
| **Wed Evening** | 1.5 h | Minimal API project + `/api/courses` | API + test |
| **Thu Evening** | 1.5 h | `/api/enrol` + NServiceBus + SQLite | Enrolment flow |
| **Sat Morning** | 2 h | GitHub Actions build/test/image | CI pipeline |
| **Sat Afternoon** | 1 h | README + security + accessibility | Docs & polish |

Stretch goals:
- [ ] Add Contentful SDK fetch
- [ ] Saga state persistence
- [ ] OWASP ZAP baseline scan

---

## 🗣️ Talking Points for Interview

- TDD & CI: “Every PR triggers build/test in CI. I used xUnit and LearningTransport locally.”
- OAuth2: “OIDC login using Azure AD with PKCE; `[Authorize]` protects routes.”
- Composite UI: “Blazor WASM app acts as a composite shell loading domain UIs.”
- REST & Storage: “Enrolments API writes to SQLite; fully test-covered.”
- GDS & Security: “Follows GOV.UK colour scheme, accessibility via Axe, enforced HTTPS.”