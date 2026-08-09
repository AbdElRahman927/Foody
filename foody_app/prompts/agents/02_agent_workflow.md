# Foody — AI Agent Workflow

## Purpose

This document defines the standard workflow that AI Agents should follow when working on the Foody project.

The workflow is designed to ensure that the Agent understands the project and the requested task before making changes.

The Agent should prioritize understanding, consistency, and correctness over implementation speed.

---

# 1. Receive the Task

When the developer provides a task, first determine:

* What is being requested?
* Which application layer is affected?
* Which feature does the task belong to?
* Which development phase does it belong to?
* Is the task implementation, debugging, refactoring, documentation, review, or planning?

Do not start modifying code immediately.

---

# 2. Identify the Current Phase

Read:

`prompts/docs/06_current_phase.md`

Determine:

* The active development phase.
* The current phase objectives.
* The current feature being implemented.
* The expected scope.
* The Definition of Done.
* Any known limitations or pending work.

Then check:

`prompts/docs/07_future_phases.md`

to ensure the requested task does not belong to a future phase unless explicitly requested.

---

# 3. Read Relevant Project Documentation

Before implementation, inspect the documentation relevant to the task.

For implementation tasks, the Agent should inspect all project documentation before making changes unless the task is clearly isolated and the relevant documentation is already known.

At minimum, the Agent must consider:

```text id="4zznwp"
01_project_overview.md
02_architecture.md
03_design_system.md
04_components.md
05_coding_guidelines.md
06_current_phase.md
08_decisions.md
```

Not every task requires deep inspection of every file.

The Agent should read the files relevant to the requested change.

---

# 4. Inspect the Existing Implementation

After understanding the documentation, inspect the actual project.

Search for:

* Related screens.
* Existing widgets.
* Existing components.
* Models.
* Services.
* Repositories.
* Navigation.
* State management.
* Existing state management patterns, if any.
* Any temporary or local state handling currently used.
* Theme usage.
* API integration.
* Existing validation.
* Local storage and persistence mechanisms.
* SharedPreferences usage where applicable.
* Similar implementations.
* Theme usage.
* API integration.
* Existing validation.
* Local storage and persistence mechanisms.
* SharedPreferences usage where applicable.
* Similar implementations.
* Local persistence.
* `SharedPreferences` usage where applicable.

The purpose is to understand how the requested feature fits into the existing codebase.

---

# 4.1 Initial Project State

The Agent must recognize that the project may begin with only a minimal implementation, such as:

- Flutter project setup.
- Existing theme configuration.
- Initial colors.
- Initial spacing values.
- Basic project configuration.

When a required implementation does not yet exist, the Agent should:

- Follow the approved architecture and coding guidelines.
- Create only what is required for the current phase.
- Avoid implementing future-phase functionality.
- Avoid introducing unnecessary abstractions.
- Avoid introducing project-wide patterns without justification.
- Reuse and extend existing foundation code where possible.

The absence of an existing implementation must not be treated as permission to invent unrelated project-wide architecture or features.

---

# 5. Compare Documentation With Code

The Agent should compare the documented project structure and decisions with the current implementation.

If documentation and implementation differ, determine whether:

* The documentation is outdated.
* The implementation is incomplete.
* The implementation intentionally differs.
* A previous decision was changed but not documented.

Do not silently choose one interpretation when the difference affects architecture, behavior, or important project decisions.

Ask the developer when clarification is required.

---

# 6. Inspect the Design System

For any UI-related task, inspect:

* `AppColors`
* `AppTextStyles`
* `AppTheme`
* `AppRadius`
* Existing reusable components
* Available Figma designs or design references, when provided.

Follow:

`prompts/docs/03_design_system.md`

Never introduce new colors, typography patterns, spacing systems, or component styles without checking whether an existing solution already exists.

If the Figma design conflicts with the current Design System, identify the conflict before implementing.

If the Figma design contains visual or behavioral details that are not clearly defined in the project documentation, ask the developer before making assumptions.

---

# 7. Search for Existing Components

Before creating a new widget or component:

1. Search the project.
2. Identify similar implementations.
3. Determine whether an existing component can be reused.
4. Determine whether it can be extended.
5. Create a new component only when necessary.

The Agent should avoid creating multiple components that provide essentially the same functionality.

Refer to:

`prompts/docs/04_components.md`

---

# 8. Analyze the Task

Once the project and existing implementation are understood, analyze the requested task.

The Agent should determine:

### Required Changes

What needs to change?

### Existing Files

Which existing files need modification?

### New Files

Which files, if any, need to be created?

### Reusable Components

Which existing components can be reused?

### Dependencies

Does the task depend on:

* Backend APIs?
* Database changes?
* Authentication?
* Navigation?
* State management?
* Existing features?

### Risks

Could the change affect existing functionality?

---

# 9. Pre-Implementation Summary

Before making significant changes, provide a concise summary to the developer containing:

### Understanding

What the Agent believes the task requires.

### Files

Files expected to be modified or created.

### Approach

How the Agent plans to implement the task.

### Dependencies

Any required dependencies or existing features.

### Concerns

Potential problems, conflicts, or unclear requirements.

For small and straightforward changes, the Agent may proceed after briefly stating the intended approach.

For changes involving:

- Architecture.
- Authentication behavior.
- API contracts.
- Data models.
- Database structure.
- Project-wide conventions.
- New packages with significant impact.
- Other significant project decisions.

the Agent must wait for developer confirmation before implementation.

---

# 10. Handle Ambiguity

If important information is missing, do not guess.

Examples include:

* Missing business rules.
* Unclear navigation behavior.
* Conflicting requirements.
* Missing API contract.
* Missing Figma behavior.
* Multiple possible implementations with significant trade-offs.
* Unclear authentication behavior.
* Unclear data ownership.

The Agent should ask the developer for clarification.

Minor implementation details that do not affect the project's architecture or behavior may be handled using reasonable assumptions.

---

# 11. Implementation

Once the task is sufficiently understood, implement the smallest correct solution.

Follow:

`prompts/docs/05_coding_guidelines.md`

The implementation should:

* Respect the existing architecture.
* Reuse existing components.
* Follow the Design System.
* Avoid unnecessary abstractions.
* Avoid unrelated refactoring.
* Avoid implementing future-phase functionality.
* Preserve working functionality.

Do not modify unrelated files unless the change is required.

---

# 12. Incremental Implementation

For larger tasks, implementation should be divided into logical steps.

Example:

```text id="f8e1o3"
Task
 ↓
Structure
 ↓
UI
 ↓
Navigation
 ↓
State / Local State
 ↓
Integration
 ↓
Validation
 ↓
Testing
```

The Agent should avoid making large numbers of unrelated changes in a single step.

---

# 13. Validate the Implementation

After implementation, review the result.

Check:

### Functionality

Does the requested feature work as expected?

### Architecture

Does the implementation follow the existing project structure?

### UI

Does it follow the Design System and Figma requirements?

### Reusability

Were existing components reused appropriately?

### Errors

Are validation, loading, error, success, and empty states handled where required?

### Integration

Does the implementation correctly interact with APIs or other application layers when applicable?

### Regression

Could the changes affect existing functionality?

### Persistence

If the feature requires local persistence, verify that the implementation follows the approved `SharedPreferences` approach where applicable.

### Flutter Quality

Check for:

- Analyzer errors and warnings.
- Unused imports.
- Unused variables.
- Invalid widget lifecycle usage.
- Layout overflow risks.
- Missing null-safety handling.
- Incorrect BuildContext usage where applicable.

---

# 14. Review the Changes

Before finishing the task, inspect the final changes.

Check for:

* Unnecessary files.
* Unused imports.
* Dead code.
* Duplicate components.
* Hardcoded colors.
* Hardcoded styles.
* Incorrect navigation.
* Incorrect state handling.
* Unnecessary dependencies.
* Debugging code.
* Temporary implementations.

The final code should contain only changes relevant to the task.

---

# 15. Documentation Updates

If the implementation introduces a significant project-level decision, update:

`prompts/docs/08_decisions.md`

If the current phase scope changes, update:

`prompts/docs/06_current_phase.md`

If a future phase changes, update:

`prompts/docs/07_future_phases.md`

Do not modify project documentation for insignificant implementation details.

---

# 16. Final Report

After completing the task, provide the developer with a concise summary.

The summary should include:

### Completed

What was implemented.

### Files Modified

Which files were changed.

### Files Created

Which new files were added.

### Components Reused

Which existing components were reused.

### Components Created

Which new reusable components were introduced.

### Dependencies

Any packages, APIs, or project dependencies involved.

### Validation

What was checked after implementation.

### Remaining Issues

Any known limitations or unresolved issues.

### Suggestions

Optional improvements that may be useful later.

Suggestions should not be implemented automatically unless requested.

### Decisions

List any decisions that were made during the implementation.

If a decision is significant or project-wide, identify whether it should be added to `docs/08_decisions.md`.

---

# 17. When the Task Cannot Be Completed Safely

If the Agent discovers that implementation depends on missing information or a significant architectural decision, it should stop before making potentially incorrect changes.

The Agent should clearly state:

1. What is missing.
2. Why it matters.
3. What possible approaches exist.
4. Which approach it recommends.
5. What decision is required from the developer.

The Agent should then wait for clarification.

---

# 18. Workflow Summary

The standard Foody workflow is:

```text id="p1g0ya"
Receive Task
     ↓
Identify Current Phase
     ↓
Read Relevant Documentation
     ↓
Inspect Existing Code
     ↓
Compare Documentation & Implementation
     ↓
Inspect Design System / Components
     ↓
Analyze Task
     ↓
Identify Risks & Ambiguities
     ↓
Summarize Plan
     ↓
Developer Confirmation (when needed)
     ↓
Implement
     ↓
Validate
     ↓
Review Changes
     ↓
Update Documentation (when required)
     ↓
Final Report
```

---

# Core Principle

The Agent should follow this sequence:

Understand
    ↓
Inspect
    ↓
Analyze
    ↓
Is clarification needed?
    ├── Yes → Ask / Discuss → Wait
    └── No
          ↓
      Implement
          ↓
       Validate
          ↓
        Review
          ↓
   Update Documentation
          ↓
        Report

The Agent should not skip the understanding and inspection stages simply because the requested implementation appears straightforward.
