var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

app.Run(async (HttpContext context) =>
{
    context.Response.ContentType = "text/Number";
    bool flag = false;
    List<string> error = new List<string>();
    if (context.Request.Method == HttpMethods.Get)
    {
        int num1 = 0, num2 = 0;
        int result = 0;
        if (context.Request.Query.ContainsKey("firstNumber"))
        {
            // Use null-coalescing operator to handle potential null values
            string firstNumber = context.Request.Query["firstNumber"].ToString() ?? string.Empty;
            if (!int.TryParse(firstNumber, out num1))
            {
                error.Add("Invalid value for firstNumber.\n");
                flag = true;
            }
        }
        else
        {
            error.Add("Invalid input for 'firstNumber'\n");
            flag = true;
        }

        if (context.Request.Query.ContainsKey("secondNumber")) 
        {
            string secondNumber = context.Request.Query["secondNumber"].ToString() ?? string.Empty;
            if (!int.TryParse(secondNumber, out num2))
            {
                error.Add("Invalid value for secondNumber.\n");
                flag = true;
            }

        }
        else
        {

            error.Add("Invalid input for 'secondNumber'\n");
            flag = true;
        }

        if (context.Request.Query.ContainsKey("operation") && context.Request.Query["operation"] == "add")
        {
            if(!flag)
            {
             result = num1 + num2;
             await context.Response.WriteAsync($"The sum of {num1} and {num2} is {result}\n");
            }
        }
        else if (context.Request.Query.ContainsKey("operation") && context.Request.Query["operation"] == "subtract")
        {
            if (!flag)
            {
                result = num1 - num2;
                await context.Response.WriteAsync($"The difference of {num1} and {num2} is {result}\n");
            }
        }
        else if (context.Request.Query.ContainsKey("operation") && context.Request.Query["operation"] == "multiply")
        {
            if (!flag)
            {
                result = num1 * num2;
                await context.Response.WriteAsync($"The product of {num1} and {num2} is {result}\n");
            }
        }
        else if (context.Request.Query.ContainsKey("operation") && context.Request.Query["operation"] == "divide")
        {
            if (!flag)
            {
                if (num2 != 0)
                {
                    if (!flag)
                    {
                        result = num1 / num2;
                        await context.Response.WriteAsync($"The quotient of {num1} and {num2} is {result}\n");
                    }
                }
                else
                {
                    error.Add("Division by zero is not allowed.\n");
                    flag = true;
                }
            }
        }
        else
        {
            error.Add("Invalid input for operation. Supported operations are: add, subtract, multiply, divide.\n");
            flag = true;
        }

    }
    else
    {
        error.Add("Unsupported HTTP method.\n");
        flag = true;
    }
    if (flag)
    {
        context.Response.StatusCode = 400;
        await context.Response.WriteAsync("Error: \n" + string.Join("", error));
        //foreach (var err in error)
        //{
        //    await context.Response.WriteAsync(err);
        //}
    }
});

app.Run();
