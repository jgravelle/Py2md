using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Get the current directory
        string currentDirectory = Directory.GetCurrentDirectory();
        string currentDirectoryName = new DirectoryInfo(currentDirectory).Name;

        // Create the markdown file name based on the current directory name
        string markdownFileName = $"{currentDirectoryName}.md";

        // Create a StreamWriter to write the markdown content to a file
        using (StreamWriter markdownFile = new StreamWriter(Path.Combine(currentDirectory, markdownFileName)))
        {
            // Traverse directories and get all .py and .yaml files
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
            Console.WriteLine(args[0]);
            if (args[0] == "-y")
            {
                var yamlFiles = Directory.GetFiles(currentDirectory, "*.yaml", SearchOption.AllDirectories);
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

        Console.WriteLine($"All files have been compiled into {markdownFileName}");
    }
}
