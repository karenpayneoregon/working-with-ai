See `Instructions.md`

![img](https://img.shields.io/static/v1?label=C%23&message=Copilot&color=<COLOR>) / 
![img](https://img.shields.io/static/v1?label=C%23&message=ChatGPT&color=<COLOR>)

## Tools used

- 99 percent was done with `GitHub Copilot`.
- `ChatGPT` was used to convert from using a table to display data to Bootstrap rows and columns which assist with WCAG AA compliance.

## DbContext configuration

Uses `ContextOptions` class to configure the `DbContext`.

### Environment specific DbContext options
- DbContextOptionsBuilderDevelopment
    - Logs to VS output window.
    - EnableSensitiveDataLogging
- DbContextOptionsBuilderProduction
    - Doesn't use `EnableSensitiveDataLogging`
    - Logs to a file under LogFiles\date
