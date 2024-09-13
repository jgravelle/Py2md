using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Get the current directory
        string currentDirectory = Directory.GetCurrentDirectory();
        string currentDirectoryName = new DirectoryInfo(currentDirectory).Name;

        // Create the 'src' directory path
        string srcDirectory = Path.Combine(currentDirectory, "src");

        // Create the 'src' directory if it doesn't exist
        if (!Directory.Exists(srcDirectory))
        {
            Directory.CreateDirectory(srcDirectory);
        }

        // Create the markdown file name based on the current directory name
        string markdownFileName = $"{currentDirectoryName}.md";
        string markdownFilePath = Path.Combine(srcDirectory, markdownFileName);

        // Create a StreamWriter to write the markdown content to a file in 'src' directory
        using (StreamWriter markdownFile = new StreamWriter(markdownFilePath, false))
        {
            // Traverse directories and get all .py files
            var pythonFiles = Directory.GetFiles(currentDirectory, "*.py", SearchOption.AllDirectories);

            // Process Python files
            foreach (var file in pythonFiles)
            {
                // Read the content of each Python file
                string fileContent = File.ReadAllText(file);

                // Get the relative path to make it clear where the file is from
                string relativePath = Path.GetRelativePath(currentDirectory, file);

                // Write the file path as a header in markdown
                markdownFile.WriteLine($"# {relativePath}");
                markdownFile.WriteLine();
                markdownFile.WriteLine("```python");
                markdownFile.WriteLine(fileContent);
                markdownFile.WriteLine("```");
                markdownFile.WriteLine();
            }

            // Check if '-y' argument is provided
            if (args.Length > 0 && args[0] == "-y")
            {
                // Traverse directories and get all .yaml files
                var yamlFiles = Directory.GetFiles(currentDirectory, "*.yaml", SearchOption.AllDirectories);

                // Process YAML files
                foreach (var file in yamlFiles)
                {
                    // Read the content of each YAML file
                    string fileContent = File.ReadAllText(file);

                    // Get the relative path to make it clear where the file is from
                    string relativePath = Path.GetRelativePath(currentDirectory, file);

                    // Write the file path as a header in markdown
                    markdownFile.WriteLine($"# {relativePath}");
                    markdownFile.WriteLine();
                    markdownFile.WriteLine("```yaml");
                    markdownFile.WriteLine(fileContent);
                    markdownFile.WriteLine("```");
                    markdownFile.WriteLine();
                }
            }
        }

        // Create 'custom_instructions.txt' in 'src' directory
        string customInstructionsPath = Path.Combine(srcDirectory, "custom_instructions.txt");
        using (StreamWriter customInstructionsFile = new StreamWriter(customInstructionsPath, false))
        {
            // Write a synopsis of the project
            string synopsis = GetProjectSynopsis(currentDirectory, currentDirectoryName);

            if (!string.IsNullOrEmpty(synopsis))
            {
                customInstructionsFile.WriteLine(synopsis);
            }
            else
            {
                customInstructionsFile.WriteLine($"[Please provide a synopsis of the {currentDirectoryName} project.]");
            }

            customInstructionsFile.WriteLine();

            // Write improved custom instructions for the AI/LLM
            customInstructionsFile.WriteLine($"Please act as an expert Python programmer and software engineer. The attached {markdownFileName} file contains the complete and up-to-date codebase for our application. Your task is to thoroughly analyze the codebase, understand its programming flow and logic, and provide detailed insights, suggestions, and solutions to enhance the application's performance, efficiency, readability, and maintainability.");
            customInstructionsFile.WriteLine();
            customInstructionsFile.WriteLine("We highly value responses that demonstrate a deep understanding of the code. Please ensure your recommendations are thoughtful, well-analyzed, and contribute positively to the project's success. Your expertise is crucial in helping us improve and upgrade our application.");
        }

        Console.WriteLine($"All files have been compiled into {markdownFilePath}");
        Console.WriteLine($"Custom instructions have been created at {customInstructionsPath}");
    }

    static string GetProjectSynopsis(string currentDirectory, string currentDirectoryName)
    {
        // Try to get a synopsis from README.md
        string readmePath = Path.Combine(currentDirectory, "README.md");
        if (File.Exists(readmePath))
        {
            string readmeContent = File.ReadAllText(readmePath);

            // Extract the first non-header, non-empty line as the synopsis
            var lines = readmeContent.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            foreach (var line in lines)
            {
                var trimmedLine = line.Trim();

                if (string.IsNullOrWhiteSpace(trimmedLine))
                    continue;

                if (trimmedLine.StartsWith("#"))
                    continue;

                if (trimmedLine.StartsWith("```"))
                    continue;

                // Found a valid line for synopsis
                return trimmedLine;
            }
        }

        // If no synopsis is found, return an empty string
        return "";
    }
}
