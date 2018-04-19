using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using ChatBot.Rest;
using ChatBot.Rest.ChatSessions;
using ChatBot.Rest.RuleSets;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QXS.ChatBot;
using QXS.ChatBot.ChatSessions;

namespace Project_OLP_Rest.Test.Tests
{
    [TestClass]
    public class PHPCourseRegexTest
    {
        private RestChatBot PHPChatBot;

        PhpCourseRuleSet phpCourseRule = new PhpCourseRuleSet();

        [TestMethod]
        public void CreatePHPBot() => PHPChatBot = new RestChatBot(phpCourseRule.Rules);

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

        // database read

        [TestMethod]
        public void PHPgetDatabaseReadTask()
        {
            CreatePHPBot();
            string Message = "db read";

            ChatSessionInterface session = new RestChatSession();
            Assert.AreEqual(PHPChatBot.FindAnswer(session, Message),
                    "Write a program that receives a database connection string (DSN). Connect to the database, query it and update some data.\n\n" +
                    "Display the information of all the users in the database table users whose age is over 30. Print out each row on a new line formatted like:" +
                    "\n\nUser: Jim Morrison Age: 27 Sex: male\n\n" +
                    "Finally you will be given a random name as the second argument to your program, you should update the row in the users table " +
                    "which corresponds to this name. You should change the name to David Attenborough"
                );

            Console.WriteLine(PHPChatBot.FindAnswer(session, Message));
        }

        [TestMethod]
        public void PHPgetDatabaseReadTaskHint()
        {
            CreatePHPBot();
            string Message = "dbr hint";

            ChatSessionInterface session = new RestChatSession();
            Assert.AreEqual(PHPChatBot.FindAnswer(session, Message), "HINTS:\n" +
                    "This is an exercise introducing databases and PDO. PDO is a powerful abstraction library for dealing with different database " +
                    "vendors in a consistent manner. You can read the PDO manual here:\n\n" +
                    "http://php.net/manual/en/book.pdo.php \n\n A short introduction can be found here: \n\n http://www.phptherightway.com/#pdo_extension \n\n" +
                    "The most interesting class will be \\PDO.The first parameter is the DSN string. The second and third are the username and password " +
                    "for the database.They are not needed for this exercise and can be left out.\n\n" +
                    "n order to get the data you will most likely want the query method. Which you can pass an SQL statement to. " +
                    "query returns an instance of PDOStatement which you can iterate over in a foreach loop, like so:\n\n" +
                    "<?php\n foreach ($pdo->query('SELECT * FROM users') as $row) {}\n\n" +
                    "$row is now an array of data. The key will be the columns and the value is the database value\n\n" +
                    "You should use prepared statements to perform the updating. You should be most interested in the prepare and execute methods.\n\n" +
                    "Remember the first argument will be the program's file path and not an argument passed to the program."
                );

            Console.WriteLine(PHPChatBot.FindAnswer(session, Message));
        }

        // time-server

        [TestMethod]
        public void PHPgetTimeServerTask()
        {
            CreatePHPBot();
            string Message = "time-server";

            ChatSessionInterface session = new RestChatSession();
            Assert.AreEqual(PHPChatBot.FindAnswer(session, Message),
                    "Write a TCP time server!\n\n Your server should listen to TCP connections on the IP address provided as the first argument" +
                    " and the port provided by the second argument to your program. For each connection you must write the current date & " +
                    "24 hour time in the format:\n\n \"YYYY-MM-DD hh:mm:ss\"\n\n followed by a newline character. Month, day, hour, minute and " +
                    "second must be zero-filled to 2 integers. For example:\n\n \"2013-07-06 17:42:30\""
                );

            Console.WriteLine(PHPChatBot.FindAnswer(session, Message));
        }

        [TestMethod]
        public void PHPgetTimeServerTaskHint()
        {
            CreatePHPBot();
            string Message = "ts hint";

            ChatSessionInterface session = new RestChatSession();
            Assert.AreEqual(PHPChatBot.FindAnswer(session, Message), "HINTS:\n" +
                    "For this exercise we'll be creating a raw TCP server. We will be using the core PHP socket_* functions. " +
                    "These functions are a thin wrapper around the C libraries.\n\n To create a server you need to use the functions socket_create," +
                    " socket_bind & socket_listen. Once the socket is listening, you can accept connections from it, which will return a new socket" +
                    " connected to the client whenever a client connects.\n\n socket_create returns a server resource. You must bind it to a host and" +
                    " port and then start listening.\n\n A typical PHP TCP server looks like this:\n\n" +
                    "<?php\n $server = socket_create(AF_INET, SOCK_STREAM, SOL_TCP); \n socket_bind($server, '127.0.0.1', 8000); \n\n socket_listen($sock);\n\n" +
                    "$client = socket_accept($server);\n\n" +
                    "Remember to use the IP address & port number supplied to you as the first and second command-line argument.\n\n" +
                    "You can read and write to the socket by using socket_read and socket_write. For this exercise we only need " +
                    "to write data and then close the socket.\n\n" +
                    "Use socket_write($client, $data, strlen($data)) to write data to the socket and then socket_close($socket) to close the socket.\n\n" +
                    "Documentation on PHP streams can be found by pointing your browser here: http://php.net/manual/en/sockets.examples.php " +
                    "http://php.net/manual/en/function.stream-socket-server.php \n\n To create the date you'll need to create a custom format from the " +
                    "PHP DateTime object. The various parameters to format() will help you. " +
                    "You can find the documentation here: http://php.net/manual/en/class.datetime.php"
                );

            Console.WriteLine(PHPChatBot.FindAnswer(session, Message));
        }

        // http json api

        [TestMethod]
        public void PHPgetHttpJsonApiTask()
        {
            CreatePHPBot();
            string Message = "http json api";

            ChatSessionInterface session = new RestChatSession();
            Assert.AreEqual(PHPChatBot.FindAnswer(session, Message),
                    "Write an HTTP server that serves JSON data when it receives a GET request to the path '/api/parsetime'. " +
                    "Expect the request to contain a query string with a key 'iso' and an ISO-format time as the value.\n\n" +
                    "For example:\n\n /api/parsetime?iso=2015-11-15T20:18:04+0000 \n\n The JSON response should contain only 'hour', " +
                    "'minute' and 'second' properties. For example:\n\n" +
                    "{\n \"hour\": 14, \n \"minute\": 23, \n \"second\": 15 \n } \n\n" +
                    "Add a second endpoint for the path '/api/unixtime' which accepts the same query string but returns UNIX epoch time in milliseconds " +
                    "(the number of milliseconds since 1 Jan 1970 00:00:00 UTC) under the property 'unixtime'. \n\n For example: \n\n" +
                    "{ \"unixtime\": 1376136615474 }"
                );

            Console.WriteLine(PHPChatBot.FindAnswer(session, Message));
        }

        [TestMethod]
        public void PHPgetHttpJsonApiTaskHint()
        {
            CreatePHPBot();
            string Message = "http-json-api hint";

            ChatSessionInterface session = new RestChatSession();
            Assert.AreEqual(PHPChatBot.FindAnswer(session, Message), "HINTS:\n" +
                    "The $_SERVER super global array has a REQUEST_URI property that you will need to use to \"route\" your requests for the two endpoints.\n\n" +
                    "You can parse the URL using the global parse_url function. The result will be an array of helpful properties. " +
                    "You can access the query string properties via the $_GET super global array. \n\n" +
                    "Documentation on the parse_url function can be found by pointing your browser here:\n http://php.net/manual/en/function.parse-url.php \n\n" +
                    "Your response should be in a JSON string format. Look at json_encode for more information.\n\n" +
                    "You should also be a good web citizen and set the Content-Type properly:\n\n" +
                    "header('Content-Type: application/json');\n\n" +
                    "The PHP DateTime object can print dates as a UNIX timestamp, e.g. (new \\DateTime())->format('U');. It can also parse this format if " +
                    "you pass the string into the \\DateTime constructor. The various parameters to format() will also come in handy. You can find the " +
                    "documentation here: http://php.net/manual/en/class.datetime.php"
                );

            Console.WriteLine(PHPChatBot.FindAnswer(session, Message));
        }

        // dependency heaven

        [TestMethod]
        public void PHPgetDependencyHeavenApiTask()
        {
            CreatePHPBot();
            string Message = "dh task";

            ChatSessionInterface session = new RestChatSession();
            Assert.AreEqual(PHPChatBot.FindAnswer(session, Message),
                    "Write an HTTP server that serves JSON data when it receives a POST request to /reverse, /swapcase and /titleize.\n" +
                    "The POST data will contain a single parameter data which you will need to manipulate depending on the endpoint.\n\n" +
                    "/reverse \n -------------------\n\n A request with data = \"PHPbot Lessons is awesome!\" should return the response: \n\n" +
                    "{ \n \"result\": \"!emosewa si snosseL tobPHP\" \n}\n\n" +
                    "/swapcase \n -------------------\n\n A request with data = \"No, It Really Is...\" should return the response:\n\n" +
                    "{ \n \"result\": \"nO, iT rEALLY iS...\" \n }\n\n" +
                    "/titleize \n -------------------\n\n A request with data = \"you know you love it, don't you?\" should return the response:\n\n" +
                    "{ \n \"result\": \"You Know You Love It, Don't You?\" \n}\n\n You should use the routing library klein/klein for this task " +
                    "pulling it in as a dependency through Composer. \n\n You will also be required to use danielstjules/stringy to manipulate the " +
                    "data as this correctly handles multibyte characters."
                );

            Console.WriteLine(PHPChatBot.FindAnswer(session, Message));
        }

        [TestMethod]
        public void PHPgetDependencyHeavenApiTaskHint()
        {
            CreatePHPBot();
            string Message = "dh hint";

            ChatSessionInterface session = new RestChatSession();
            Assert.AreEqual(PHPChatBot.FindAnswer(session, Message), "HINTS:\n" +
                    "Point your browser to https://getcomposer.org/doc/00-intro.md which will walk you through Installing Composer if you haven't already!\n\n" +
                    "Use composer init to create your composer.json file with interactive search. \n\n" +
                    "For more details look at the docs for... \n\n" +
                    "Composer - https://getcomposer.org/doc/01-basic-usage.md Klein - https://github.com/chriso/klein.php " +
                    "Stringy - https://github.com/danielstjules/Stringy \n\n Oh, and don't forget to use the Composer autoloader with: \n\n" +
                    "require_once __DIR__ . '/vendor/autoload.php';"
                );

            Console.WriteLine(PHPChatBot.FindAnswer(session, Message));
        }

    }
}
