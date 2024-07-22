// Initialize Variables
string? usrInput;
string[] ops;
Dictionary<string, List<string>> dictionary;
bool exit;

dictionary = new Dictionary<string, List<string>>();
exit = false;

// Start Loop for managing dictionary
while (!exit)
{
    usrInput = Console.ReadLine();

    if (usrInput == null || usrInput == "")
    {
        Console.WriteLine("Invalid Command");
        continue;
    }

    ops = usrInput.Split(' ');

    switch (ops[0].ToLower())
    {
        case "add":
            if (ops.Length != 3)
            {
                Console.WriteLine("Invalid Command");
                break;
            }

            if (dictionary.ContainsKey(ops[1])) {
                if (dictionary[ops[1]].Contains(ops[2]))
                {
                    Console.WriteLine("ERROR, member already exists for key");
                    break;
                }
                
                dictionary[ops[1]].Add(ops[2]);
            } else
            {
                dictionary.Add(ops[1], new List<string>() { ops[2] });
            }

            Console.WriteLine("Added");
        break;
        case "remove":
            if (ops.Length != 3)
            {
                Console.WriteLine("Invalid Command");
                break;
            }

            if (!dictionary.ContainsKey(ops[1]))
            {
                Console.WriteLine("ERROR, key does not exist.");
                break;
            }

            if (!dictionary[ops[1]].Contains(ops[2]))
            {
                Console.WriteLine("ERROR, member does not exist.");
                break;
            }

            dictionary[ops[1]].Remove(ops[2]);

            if (dictionary[ops[1]].Count == 0)
            {
                dictionary.Remove(ops[1]);
            }
            Console.WriteLine("Removed");
        break;
        case "removeall":
            if (ops.Length != 2)
            {
                Console.WriteLine("Invalid Command");
                break;
            }

            if (!dictionary.ContainsKey(ops[1]))
            {
                Console.WriteLine("ERROR, key does not exist.");
                break;
            }

            dictionary.Remove(ops[1]);
            Console.WriteLine("Removed");
        break;
        case "clear":
            dictionary.Clear();
            Console.WriteLine("Cleared");
        break;
        case "keyexists":
            if (ops.Length != 2)
            {
                Console.WriteLine("Invalid Command");
                break;
            }

            if (dictionary.ContainsKey(ops[1]))
            {
                Console.WriteLine("true");
                break;
            }

            Console.WriteLine("false");
        break;
        case "memberexists":
            if (ops.Length != 3)
            {
                Console.WriteLine("Invalid Command");
                break;
            }

            if (dictionary.ContainsKey(ops[1]) && dictionary[ops[1]].Contains(ops[2]))
            {
                Console.WriteLine("true");
                break;
            }

            Console.WriteLine("false");
        break;
        case "keys":
            if (dictionary.Count() == 0)
            {
                Console.WriteLine("empty set");
                break;
            }

            for (int i = 0; i < dictionary.Count(); i++)
            {
                Console.WriteLine((i + 1) + ") " + dictionary.ElementAt(i).Key);
            }
        break;
        case "members":
            if (ops.Length != 2)
            {
                Console.WriteLine("Invalid Command");
                break;
            }

            if (!dictionary.ContainsKey(ops[1]))
            {
                Console.WriteLine("ERROR, key does not exist.");
                break;
            }

            for (int i = 0; i < dictionary[ops[1]].Count(); i++)
            {
                Console.WriteLine((i + 1) + ") " + dictionary[ops[1]][i]);
            }
        break;
        case "allmembers":
            int totalCount;

            if (dictionary.Count == 0)
            {
                Console.WriteLine("(empty set)");
                break;
            }

            totalCount = 1;
            for (int i = 0; i < dictionary.Count(); i++)
            {
                for (int j = 0; j < dictionary.ElementAt(i).Value.Count; j++)
                {
                    Console.WriteLine(totalCount + ") " + dictionary.ElementAt(i).Value.ElementAt(j));
                    totalCount++;
                }
            }
            
        break;
        case "items":
            int listCount;

            if (dictionary.Count == 0)
            {
                Console.WriteLine("(empty set)");
                break;
            }

            listCount = 1;
            for (int i = 0; i < dictionary.Count(); i++)
            {
                for (int j = 0; j < dictionary.ElementAt(i).Value.Count; j++)
                {
                    Console.WriteLine(listCount + ") " + dictionary.ElementAt(i).Key + ": " + dictionary.ElementAt(i).Value.ElementAt(j));
                    listCount++;
                }
            }
        break;
        default:
            Console.WriteLine("Invalid Command");
        break;
    }
}

