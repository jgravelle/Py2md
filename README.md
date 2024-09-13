# py2md

*A streamlined solution to prepare your Python projects for AI-assisted development and enhancement.*
![py2md](https://github.com/user-attachments/assets/166fb046-8695-46bf-b7bc-626ee16dbddc)


## Overview

**py2md** is a powerful yet easy-to-use tool that automates the process of preparing your Python project for interaction with Large Language Models (LLMs). By compiling your entire codebase into a single Markdown file and generating custom instructions, py2md enables efficient and effective collaboration with AI assistants to troubleshoot, optimize, and enhance your code.

## Features

- **Ease of Use**: With a simple command-line interface, py2md can be executed from the root folder of any Python project without any complex setup.
- **Comprehensive Code Compilation**: Automatically gathers all `.py` files (and optional `.yaml` files) in your project and compiles them into a neatly formatted Markdown file.
- **Custom Instructions Generation**: Creates a `custom_instructions.txt` file tailored for AI assistants, ensuring they have the context and guidance needed to provide meaningful assistance.
- **Time-Saving**: Eliminates the manual effort of preparing your codebase for AI analysis, allowing you to focus on development.
- **Improved AI Collaboration**: Facilitates more effective interactions with LLMs by providing complete code context and clear instructions.

## Benefits

- **Accelerated Development**: Quickly onboard AI assistants to help improve your code, reducing development time.
- **Enhanced Code Quality**: Receive insightful suggestions from AI on performance, efficiency, readability, and maintainability.
- **Simplified Workflow**: Integrate AI assistance seamlessly into your development process without disrupting your existing workflow.

## Installation

1. **Clone or Download the Repository**

   Clone the repository or download the source code to your local machine.

   ```bash
   git clone https://github.com/yourusername/py2md.git
   ```

2. **Build the Executable**

   - Open the project in your preferred C# development environment (e.g., Visual Studio).
   - Build the project to generate the `py2md` executable.

3. **Add to System Path**

   Add the directory containing the `py2md` executable to your system's PATH environment variable to run it from any location.

## Usage

1. **Navigate to Your Python Project**

   Open a terminal window and navigate to the root directory of the Python project you wish to prepare.

   ```bash
   cd /path/to/your/python/project
   ```

2. **Run py2md**

   Execute the `py2md` command to generate the Markdown file and custom instructions.

   ```bash
   py2md
   ```

   To include `.yaml` files in the compilation, use the `-y` flag:

   ```bash
   py2md -y
   ```

3. **Output**

   - A `src/` directory will be created if it doesn't exist.
   - Inside `src/`, you'll find:
     - `your_project_name.md`: A Markdown file containing all your `.py` (and optionally `.yaml`) files.
     - `custom_instructions.txt`: A file containing tailored instructions for AI assistants.

## How It Works

- **Code Aggregation**: py2md recursively searches your project directory for all `.py` files and compiles their content into a single Markdown file with proper formatting and syntax highlighting.
- **Optional YAML Inclusion**: By using the `-y` flag, py2md also includes `.yaml` files, ensuring configuration files are part of the AI's context.
- **Custom Instructions**: Generates a `custom_instructions.txt` file that provides AI assistants with a project synopsis and clear guidance on how to assist effectively.

## Example

After running `py2md`, suppose your project is named `MyAwesomeProject`, the `src/` directory will contain:

- **`MyAwesomeProject.md`**

  ```markdown
  # path/to/first_file.py

  ```python
  # Contents of first_file.py
  ```

  # path/to/second_file.py

  ```python
  # Contents of second_file.py
  ```

  # path/to/config.yaml

  ```yaml
  # Contents of config.yaml
  ```
  ```

- **`custom_instructions.txt`**

  ```text
  [Project Synopsis]

  Please act as an expert Python programmer and software engineer. The attached MyAwesomeProject.md file contains the complete and up-to-date codebase for our application. Your task is to thoroughly analyze the codebase, understand its programming flow and logic, and provide detailed insights, suggestions, and solutions to enhance the application's performance, efficiency, readability, and maintainability.

  We highly value responses that demonstrate a deep understanding of the code. Please ensure your recommendations are thoughtful, well-analyzed, and contribute positively to the project's success. Your expertise is crucial in helping us improve and upgrade our application.
  ```

## Best Practices

- **Update Regularly**: Run py2md whenever you make significant changes to your codebase to keep the Markdown file and instructions up-to-date.
- **Provide a Project Synopsis**: Ensure your `README.md` contains a concise project description, as py2md extracts this for the AI assistant's context.
- **Review Before Sharing**: Check the generated files to ensure sensitive information is not inadvertently shared with AI services.

## Contributing

Contributions are welcome! If you have suggestions for improvements or new features, please open an issue or submit a pull request on GitHub.

## License

This project is licensed under the [MIT License](LICENSE).

## Contact

For questions or support, please contact [J. Gravelle](mailto:j@gravelle.us).

![py2md](https://github.com/user-attachments/assets/570c602d-de7f-41d5-9c1e-b38d7eb06118)

