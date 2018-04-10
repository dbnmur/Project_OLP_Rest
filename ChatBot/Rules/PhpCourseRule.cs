using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QXS.ChatBot.Rules
{
    public class PHPCourseRule
    {
        public List<BotRule> CourseRule = new List<BotRule>()
        {
            new BotRule(
                Name: "setcoursename",
                Weight: 10,
                MessagePattern: new Regex("(course name is|course is) (now )?(.*)", RegexOptions.IgnoreCase),
                Process: delegate(Match match, ChatSessionInterface session) {
                    session.SessionStorage.Values["CourseName"] = match.Groups[3].Value;
                    return "Course name now is " + session.SessionStorage.Values["CourseName"];
                }
            ),

            new BotRule(
                Name: "getcoursename",
                Weight: 10,
                MessagePattern: new Regex("(what course name|(what is|say) course name)", RegexOptions.IgnoreCase),
                Process: delegate(Match match, ChatSessionInterface session) {
                    if (!session.SessionStorage.Values.ContainsKey("CourseName"))
                    {
                        return "I do not know course name";
                    }
                    if (match.Value.ToLower() == "what course")
                    {
                        return "course is " + session.SessionStorage.Values["CourseName"];
                    }
                    return "You are in " + session.SessionStorage.Values["CourseName"];
                }
            ),

            new BotRule(
                Name: "showexcersices",
                Weight: 10,
                MessagePattern: new Regex("(show excersices|(teach me|give me tasks) php)", RegexOptions.IgnoreCase),
                Process: delegate(Match match, ChatSessionInterface session) {
                    if (match.Value.ToLower() == "teach me php")
                        {
                            return "Choose excersise from list bellow\n\n" +
                            "PHP EXCERCISES: \n" + "-------------------\n" + "Hello World\n" + "Baby Steps\n" +
                            "My First IO\n" + "Filtered LS\n" + "Concerned about Separation?\n" + "Array We Go!\n" +
                            "Exceptional Coding\n" + "Database Read\n" + "Time server\n" + "HTTP JSON API\n" +
                            "Dependency Heaven\n";
                        }
                    return "PHP EXCERCISES: \n" + "-------------------\n" + "Hello World\n" + "Baby Steps\n" +
                        "My First IO\n" + "Filtered LS\n" + "Concerned about Separation?\n" + "Array We Go!\n" +
                        "Exceptional Coding\n" + "Database Read\n" + "Time server\n" + "HTTP JSON API\n" +
                        "Dependency Heaven\n";
                }
            ),

            // Hello World

            new BotRule(
                Name: "selecthelloworldexcersice",
                Weight: 10,
                MessagePattern: new Regex("(hello world|(give me hello world|hw) task)", RegexOptions.IgnoreCase),
                Process: delegate(Match match, ChatSessionInterface session) {
                    return "Write a program that prints the text \"Hello World\" to the console (stdout).";
                }
            ),

            new BotRule(
                Name: "helloworldexcersicehint",
                Weight: 11,
                MessagePattern: new Regex("(hello world hint|(give me hello world|hw) hint)", RegexOptions.IgnoreCase),
                Process: delegate(Match match, ChatSessionInterface session) {
                    return "HINTS:\n" +
                    "To make a PHP program, create a new file with a .php extension and start writing PHP! " +
                    "Execute your program by running it with the php command. e.g.:\n" +
                    "\n$ php program.php\n\n" +
                    "You can write to the console from a PHP program with the following code" +
                    "\n\n<?php \n echo \"text\"\n" +
                    "\n The first line tells the PHP to interpret the code following it. It is required before any PHP code is written." +
                    "Read more here: http://php.net/manual/en/language.basic-syntax.phptags.php The second line is the instruction to print out some text.";
                }
            ),

            //Baby-Steps 

                new BotRule(
                Name: "selectbabystepsexcersice",
                Weight: 10,
                MessagePattern: new Regex("(baby-steps|baby steps|(give me baby steps|bs|give me baby-steps) task)", RegexOptions.IgnoreCase),
                Process: delegate(Match match, ChatSessionInterface session) {
                    return "Write a program that accepts one or more numbers as command-line arguments " +
                    "and prints the sum of those numbers to the console (stdout).";
                }
            ),

            new BotRule(
                Name: "babystepsexcersicehint",
                Weight: 11,
                MessagePattern: new Regex("(baby-steps hint|baby steps hint|(give me baby steps|bs|give me baby-steps) hint)", RegexOptions.IgnoreCase),
                Process: delegate(Match match, ChatSessionInterface session) {
                    return "HINTS:\n" +
                    "You can access command-line arguments via the global $argv array.\n" +
                    "To get started, write a program that simply contains:\n" +
                    "\nvar_dump($argv);\n\n" +
                    "Run it with php program.php and some numbers as arguments. e.g:\n\n" +
                    "$ php program.php 1 2 3\n\n" +
                    "You'll need to think about how to loop through the number of arguments so you can output just their sum. " +
                    "The first element of the $argv array is always the name of your script. eg program.php, " +
                    "so you need to start at the 2nd element (index 1), adding each item to the total until you reach the end of the array.";
                }
            ),

            // My first IO

            new BotRule(
                Name: "selectmyfirstioexcersice",
                Weight: 10,
                MessagePattern: new Regex("(my-first-io|my first io|(give me my first io|mfio|give me my-first-io) task)", RegexOptions.IgnoreCase),
                Process: delegate(Match match, ChatSessionInterface session) {
                    return "Write a program that uses a single filesystem operation to read a file and print the number of newlines (\\n) " +
                    "it contains to the console (stdout), similar to running cat file | wc -l.\n" +
                    "The full path to the file to read will be provided as the first command-line argument. You do not need to make your own test file.";
                }
            ),

            new BotRule(
                Name: "myfirstioexcersicehint",
                Weight: 11,
                MessagePattern: new Regex("(my-first-io hint|my first io hint|(give me my first io|mfio|give me my-first-io) hint)", RegexOptions.IgnoreCase),
                Process: delegate(Match match, ChatSessionInterface session) {
                    return "HINTS:\n" +
                    "To perform a filesystem operation you can use the global PHP functions.\n\n" +
                    "To read a file, you'll need to use file_get_contents('/path/to/file'). This method will return" +
                    " a string containing the complete contents of the file.\n\n" +
                    "Documentation on the file_get_contents function can be found by pointing your browser " +
                    "here: http://php.net/manual/en/function.file-get-contents.php \n\n" +
                    "If you're looking for an easy way to count the number of newlines in a string, recall the PHP " +
                    "function substr_count can be used to count the number of substring occurrences.";
                }
            ),

            // Filter-ls

                new BotRule(
                Name: "selectfilterlsexcersice",
                Weight: 10,
                MessagePattern: new Regex("(filter-ls|filter ls|(give me filter ls|fls|give me filter-ls) task)", RegexOptions.IgnoreCase),
                Process: delegate(Match match, ChatSessionInterface session) {
                    return "Create a program that prints a list of files in a given directory, filtered by the extension of the files. " +
                    "You will be provided a directory name as the first argument to your program (e.g. '/path/to/dir/') and a file" +
                    " extension to filter by as the second argument.\n\n" +
                    "For example, if you get 'txt' as the second argument then you will need to filter the list to only files that end with .txt. " +
                    "Note that the second argument will not come prefixed with a '.'.\n\n" +
                    "The list of files should be printed to the console, one file per line.";
                }
            ),

            new BotRule(
                Name: "filterlsexcersicehint",
                Weight: 11,
                MessagePattern: new Regex("(filter-ls hint|filter ls hint|(give me filter ls|fls|give me filter-ls) hint)", RegexOptions.IgnoreCase),
                Process: delegate(Match match, ChatSessionInterface session) {
                    return "HINTS:\n" +
                    "The DirectoryIterator class takes a pathname as its first argument." +
                    " Using an iterator in a foreach loop will provide you with a SplFileInfo object for each file.\n\n" +
                    "<?php \n" +
                    "foreach (new DirectoryIterator('/some/path') as $file) {}\n\n" +
                    "Documentation on the SplFileInfo class can be found by pointing your browser here:\n\n" +
                    "http://php.net/manual/en/class.splfileinfo.php \n\n" +
                    "You may also find SplFileInfo's getExtension() method helpful \n\n" +
                    "Documentation on the getExtension() method can be found by pointing " +
                    "your browser here: http://php.net/manual/en/splfileinfo.getextension.php";
                }
            ),

            // Concerned about separation

                new BotRule(
                Name: "selectconcernedaboutseperationexcersice",
                Weight: 10,
                MessagePattern: new Regex("(concerned-about-separation|concerned about separation|" +
                    "(give me concerned about separation|cas|give me concerned-about-separation) task)", RegexOptions.IgnoreCase),
                Process: delegate(Match match, ChatSessionInterface session) {
                    return "This problem is the same as the previous but introduces the concept of classes. You will need to create two files to solve this.\n\n" +
                    "Create a program that prints a list of files in a given directory, filtered by the extension of the files. The first argument is the " +
                    "directory name and the second argument is the extension filter. Print the list of files (one file per line) to the console.\n\n" +
                    "You must write a class file to do most of the work. The file must define a single class with a single function that takes two arguments:" +
                    " the directory name and the filename extension string in that order. The filename extension argument must be the same as what was passed" +
                    " to your program. Don't turn it into a regular expression or prefix with \".\" or do anything except pass it to your class method where " +
                    "you can do what you need to make your filter work.\n\n" +
                    "You must not print directly to the console from your class, only from your original program.\n\n" +
                    "The benefit of having a contract like this is that your class can be used by anyone who expects this contract. " +
                    "So your class could be used by anyone else who does learnyouphp, or the verifier, and just work.";
                }
            ),

            new BotRule(
                Name: "concernedaboutseparationexcersicehint",
                Weight: 11,
                MessagePattern: new Regex("(concerned-about-separation hint|concerned about separation hint|" +
                    "(give me concerned about separation|cas|give me concerned-about-separation) hint)", RegexOptions.IgnoreCase),
                Process: delegate(Match match, ChatSessionInterface session) {
                    return "HINTS:\n" +
                    "Create a new class by creating a new file that just contains your directory reading and filtering " +
                    "code in a class method. To define a single method class, use the following syntax:\n\n" +
                    "<?php\n\n class DirectoryFilter \n {\n public function filter($args) {} \n } \n\n" +
                    "To use your new class in your original program file, use the require_once construct with the filename." +
                    " So, if your file is named mymodule.php then:\n\n<?php\nrequire_once __DIR__ . '/mymodule.php'\n\n" +
                    "You can now create an instance of your class and assign it to a variable!\n\n <?php \n$myFilter = new DirectoryFilter;\n\n" +
                    "You can then call the method you defined with its required arguments.\n\n" +
                    "Documentation on class basics can be found here:\n\n" +
                    "http://php.net/manual/en/language.oop5.basic.php \n\n" +
                    "Documentation on require_once can be found here:\n\n" +
                    "http://php.net/manual/en/function.require-once.php";
                }
            ),

            // Array We go

                new BotRule(
                Name: "selectarraywegoexcersice",
                Weight: 10,
                MessagePattern: new Regex("(array-we-go|array we go|" +
                    "(give me array we go|awg|give me array-we-go) task)", RegexOptions.IgnoreCase),
                Process: delegate(Match match, ChatSessionInterface session) {
                    return "Write a program that takes an array of filepaths as arguments, filtering " +
                    "out files that do not exist and mapping existing files to SplFileObject's.\n\n" +
                    "Finally output the basename of the files, each on a new line.\n\n " +
                    "The full path of the files to read will be provided as the command line arguments. You do not need to make your own test files.";
                }
            ),

            new BotRule(
                Name: "arraywegoexcersicehint",
                Weight: 11,
                MessagePattern: new Regex("(array-we-go hint|array we go hint|" +
                    "(give me array we go|awg|give me array-we-go) hint)", RegexOptions.IgnoreCase),
                Process: delegate(Match match, ChatSessionInterface session) {
                    return "HINTS:\n" +
                    "Remember the first argument will be the programs file path and not an argument passed to the program.\n\n" +
                    "You will be expected to make use of core array functions, array_shift, array_filter and array_map.\n\n" +
                    "To check a file exists you will need to use file_exists($filePath). This method will return a boolean true or false.\n\n" +
                    "Documentation on the SplFileObject class can be found by pointing your browser here:\n http://php.net/manual/en/class.splfileobject.php";
                }
            ),
        };
    }
}
