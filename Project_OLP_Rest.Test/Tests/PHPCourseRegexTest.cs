using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QXS.ChatBot;
using QXS.ChatBot.ChatSessions;
using QXS.ChatBot.Rules;

namespace Project_OLP_Rest.Test.Tests
{
    [TestClass]
    public class PHPCourseRegexTest
    {
        private RestChatBot PHPChatBot;

        PHPCourseRule phpCourseRule = new PHPCourseRule();

        [TestMethod]
        public void CreatePHPBot() => PHPChatBot = new RestChatBot(phpCourseRule.CourseRule);

        [TestMethod]
        public void PHPCourseNameTest()
        {
            CreatePHPBot();
            string Message = "What course name";

            ChatSessionInterface session = new RestChatSession();
            Assert.AreEqual(PHPChatBot.FindAnswer(session, Message), "I do not know course name");

            Console.WriteLine(PHPChatBot.FindAnswer(session, Message));
        }

        [TestMethod]
        public void PHPgetExercisesListTest()
        {
            CreatePHPBot();
            string Message = "show excersices";

            ChatSessionInterface session = new RestChatSession();
            Assert.AreEqual(PHPChatBot.FindAnswer(session, Message), "PHP EXCERCISES: \n" + "-------------------\n" + "Hello World\n" + "Baby Steps\n" +
                    "My First IO\n" + "Filtered LS\n" + "Concerned about Separation?\n" + "Array We Go!\n" +
                    "Exceptional Coding\n" + "Database Read\n" + "Time server\n" + "HTTP JSON API\n" +
                    "Dependency Heaven\n"
                );

            Console.WriteLine(PHPChatBot.FindAnswer(session, Message));
        }

        [TestMethod]
        public void PHPgetExercisesListWithTeachMePHPMessageTest()
        {
            CreatePHPBot();
            string Message = "teach me php";

            ChatSessionInterface session = new RestChatSession();
            Assert.AreEqual(PHPChatBot.FindAnswer(session, Message), "Choose excersise from list bellow\n\n" +
                    "PHP EXCERCISES: \n" + "-------------------\n" + "Hello World\n" + "Baby Steps\n" +
                    "My First IO\n" + "Filtered LS\n" + "Concerned about Separation?\n" + "Array We Go!\n" +
                    "Exceptional Coding\n" + "Database Read\n" + "Time server\n" + "HTTP JSON API\n" +
                    "Dependency Heaven\n"
                );

            Console.WriteLine(PHPChatBot.FindAnswer(session, Message));
        }

        // Hello World

        [TestMethod]
        public void PHPgetHelloWorldTask()
        {
            CreatePHPBot();
            string Message = "give me hello world task";

            ChatSessionInterface session = new RestChatSession();
            Assert.AreEqual(PHPChatBot.FindAnswer(session, Message),
                "Write a program that prints the text \"Hello World\" to the console (stdout).");

            Console.WriteLine(PHPChatBot.FindAnswer(session, Message));
        }

        [TestMethod]
        public void PHPgetHelloWorldTaskHint()
        {
            CreatePHPBot();
            string Message = "hw hint";
            ChatSessionInterface session = new RestChatSession();
            Assert.AreEqual(PHPChatBot.FindAnswer(session, Message), "HINTS:\n" +
                    "To make a PHP program, create a new file with a .php extension and start writing PHP! " +
                    "Execute your program by running it with the php command. e.g.:\n" +
                    "\n$ php program.php\n\n" +
                    "You can write to the console from a PHP program with the following code" +
                    "\n\n<?php \n echo \"text\"\n" +
                    "\n The first line tells the PHP to interpret the code following it. It is required before any PHP code is written." +
                    "Read more here: http://php.net/manual/en/language.basic-syntax.phptags.php The second line is the instruction to print out some text."
                );

            Console.WriteLine(PHPChatBot.FindAnswer(session, Message));
        }

        //Baby-Steps

        [TestMethod]
        public void PHPgetBabyStepsTask()
        {
            CreatePHPBot();
            string Message = "give me baby steps task";

            ChatSessionInterface session = new RestChatSession();
            Assert.AreEqual(PHPChatBot.FindAnswer(session, Message),
                    "Write a program that accepts one or more numbers as command-line arguments " +
                    "and prints the sum of those numbers to the console (stdout)."
                );

            Console.WriteLine(PHPChatBot.FindAnswer(session, Message));
        }

        [TestMethod]
        public void PHPgetBabyStepsTaskHint()
        {
            CreatePHPBot();
            string Message = "bs hint";
            ChatSessionInterface session = new RestChatSession();
            Assert.AreEqual(PHPChatBot.FindAnswer(session, Message), "HINTS:\n" +
                    "You can access command-line arguments via the global $argv array.\n" +
                    "To get started, write a program that simply contains:\n" +
                    "\nvar_dump($argv);\n\n" +
                    "Run it with php program.php and some numbers as arguments. e.g:\n\n" +
                    "$ php program.php 1 2 3\n\n" +
                    "You'll need to think about how to loop through the number of arguments so you can output just their sum. " +
                    "The first element of the $argv array is always the name of your script. eg program.php, " +
                    "so you need to start at the 2nd element (index 1), adding each item to the total until you reach the end of the array."
                );

            Console.WriteLine(PHPChatBot.FindAnswer(session, Message));
        }

        // My First IO

        [TestMethod]
        public void PHPgetMyFirstIOTask()
        {
            CreatePHPBot();
            string Message = "my-first-io";

            ChatSessionInterface session = new RestChatSession();
            Assert.AreEqual(PHPChatBot.FindAnswer(session, Message),
                    "Write a program that uses a single filesystem operation to read a file and print the number of newlines (\\n) " +
                    "it contains to the console (stdout), similar to running cat file | wc -l.\n" +
                    "The full path to the file to read will be provided as the first command-line argument. You do not need to make your own test file."
                );

            Console.WriteLine(PHPChatBot.FindAnswer(session, Message));
        }

        [TestMethod]
        public void PHPgetMyFirstiIOTaskHint()
        {
            CreatePHPBot();
            string Message = "mfio hint";
            ChatSessionInterface session = new RestChatSession();
            Assert.AreEqual(PHPChatBot.FindAnswer(session, Message), "HINTS:\n" +
                    "To perform a filesystem operation you can use the global PHP functions.\n\n" +
                    "To read a file, you'll need to use file_get_contents('/path/to/file'). This method will return" +
                    " a string containing the complete contents of the file.\n\n" +
                    "Documentation on the file_get_contents function can be found by pointing your browser " +
                    "here: http://php.net/manual/en/function.file-get-contents.php \n\n" +
                    "If you're looking for an easy way to count the number of newlines in a string, recall the PHP " +
                    "function substr_count can be used to count the number of substring occurrences."
                );

            Console.WriteLine(PHPChatBot.FindAnswer(session, Message));
        }

        // Filter-ls

        [TestMethod]
        public void PHPgetFilterLSTask()
        {
            CreatePHPBot();
            string Message = "fls task";

            ChatSessionInterface session = new RestChatSession();
            Assert.AreEqual(PHPChatBot.FindAnswer(session, Message),
                    "Create a program that prints a list of files in a given directory, filtered by the extension of the files. " +
                    "You will be provided a directory name as the first argument to your program (e.g. '/path/to/dir/') and a file" +
                    " extension to filter by as the second argument.\n\n" +
                    "For example, if you get 'txt' as the second argument then you will need to filter the list to only files that end with .txt. " +
                    "Note that the second argument will not come prefixed with a '.'.\n\n" +
                    "The list of files should be printed to the console, one file per line."
                );

            Console.WriteLine(PHPChatBot.FindAnswer(session, Message));
        }

        [TestMethod]
        public void PHPgetFilterLSTaskHint()
        {
            CreatePHPBot();
            string Message = "filter ls hint";

            ChatSessionInterface session = new RestChatSession();
            Assert.AreEqual(PHPChatBot.FindAnswer(session, Message), "HINTS:\n" +
                    "The DirectoryIterator class takes a pathname as its first argument." +
                    " Using an iterator in a foreach loop will provide you with a SplFileInfo object for each file.\n\n" +
                    "<?php \n" +
                    "foreach (new DirectoryIterator('/some/path') as $file) {}\n\n" +
                    "Documentation on the SplFileInfo class can be found by pointing your browser here:\n\n" +
                    "http://php.net/manual/en/class.splfileinfo.php \n\n" +
                    "You may also find SplFileInfo's getExtension() method helpful \n\n" +
                    "Documentation on the getExtension() method can be found by pointing " +
                    "your browser here: http://php.net/manual/en/splfileinfo.getextension.php"
                );

            Console.WriteLine(PHPChatBot.FindAnswer(session, Message));
        }

        // Concerned about separation

        [TestMethod]
        public void PHPgetConcernedAboutSeparationTask()
        {
            CreatePHPBot();
            string Message = "concerned about separation task";

            ChatSessionInterface session = new RestChatSession();
            Assert.AreEqual(PHPChatBot.FindAnswer(session, Message),
                    "This problem is the same as the previous but introduces the concept of classes. You will need to create two files to solve this.\n\n" +
                    "Create a program that prints a list of files in a given directory, filtered by the extension of the files. The first argument is the " +
                    "directory name and the second argument is the extension filter. Print the list of files (one file per line) to the console.\n\n" +
                    "You must write a class file to do most of the work. The file must define a single class with a single function that takes two arguments:" +
                    " the directory name and the filename extension string in that order. The filename extension argument must be the same as what was passed" +
                    " to your program. Don't turn it into a regular expression or prefix with \".\" or do anything except pass it to your class method where " +
                    "you can do what you need to make your filter work.\n\n" +
                    "You must not print directly to the console from your class, only from your original program.\n\n" +
                    "The benefit of having a contract like this is that your class can be used by anyone who expects this contract. " +
                    "So your class could be used by anyone else who does learnyouphp, or the verifier, and just work."
                );

            Console.WriteLine(PHPChatBot.FindAnswer(session, Message));
        }

        [TestMethod]
        public void PHPgetConcernedAboutSeparationTaskHint()
        {
            CreatePHPBot();
            string Message = "concerned-about-separation hint";

            ChatSessionInterface session = new RestChatSession();
            Assert.AreEqual(PHPChatBot.FindAnswer(session, Message), "HINTS:\n" +
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
                    "http://php.net/manual/en/function.require-once.php" 
                );

            Console.WriteLine(PHPChatBot.FindAnswer(session, Message));
        }

        // Array We Go

        [TestMethod]
        public void PHPgetArrayWeGoTask()
        {
            CreatePHPBot();
            string Message = "array we go task";

            ChatSessionInterface session = new RestChatSession();
            Assert.AreEqual(PHPChatBot.FindAnswer(session, Message),
                    "Write a program that takes an array of filepaths as arguments, filtering " +
                    "out files that do not exist and mapping existing files to SplFileObject's.\n\n" +
                    "Finally output the basename of the files, each on a new line.\n\n " +
                    "The full path of the files to read will be provided as the command line arguments. You do not need to make your own test files."
                );

            Console.WriteLine(PHPChatBot.FindAnswer(session, Message));
        }

        [TestMethod]
        public void PHPgetArrayWeGoTaskHint()
        {
            CreatePHPBot();
            string Message = "array-we-go hint";

            ChatSessionInterface session = new RestChatSession();
            Assert.AreEqual(PHPChatBot.FindAnswer(session, Message), "HINTS:\n" +
                    "Remember the first argument will be the programs file path and not an argument passed to the program.\n\n" +
                    "You will be expected to make use of core array functions, array_shift, array_filter and array_map.\n\n" +
                    "To check a file exists you will need to use file_exists($filePath). This method will return a boolean true or false.\n\n" +
                    "Documentation on the SplFileObject class can be found by pointing your browser here:\n http://php.net/manual/en/class.splfileobject.php"
                );

            Console.WriteLine(PHPChatBot.FindAnswer(session, Message));
        }

        // Exceptional Coding

        [TestMethod]
        public void PHPgetExceptionalCodingTask()
        {
            CreatePHPBot();
            string Message = "exceptional-coding";

            ChatSessionInterface session = new RestChatSession();
            Assert.AreEqual(PHPChatBot.FindAnswer(session, Message),
                    "Write a program that takes an array of filepaths as arguments and outputs the basename of each, separated by a new line.\n\n" +
                    "Every file should exist but under exceptional circumstances some files may not. If this occurs, output a message similar to the below.\n\n" +
                    "Unable to open file at path '/file/path'\n\n" +
                    "The full path of the files to read will be provided as the command line arguments. You do not need to make your own test files."
                );

            Console.WriteLine(PHPChatBot.FindAnswer(session, Message));
        }

        [TestMethod]
        public void PHPgetExceptionalCodingTaskHint()
        {
            CreatePHPBot();
            string Message = "ec hint";

            ChatSessionInterface session = new RestChatSession();
            Assert.AreEqual(PHPChatBot.FindAnswer(session, Message), "HINTS:\n" +
                    "You are urged to use try... catch logic here along with the SplFileObject contruct which " +
                    "throws a RuntimeException when a file does not exist.\n\n" +
                    "Documentation on the SplFileObject class can be found by pointing your browser here:\n http://php.net/manual/en/class.splfileobject.php"
                );

            Console.WriteLine(PHPChatBot.FindAnswer(session, Message));
        }
    }
}
