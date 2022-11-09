# ## # Azure durable functions azure with CQRS using Fan out/fan in.
In here I have implemented for fan out/fan in pattern for handling from http trigger function end-point and as well as queue trigger end-point.

I have to downgrade the package Microsoft.Azure.WebJobs.Extensions.DurableTask to 1.8.3 due to access DurableOrchestrationClient for handling both queue and http triggering endpoint requests.

And also I had faced some issue when direct calling CQRS commands from the RunOrchestrator function. Basically issue was retrieving data from Db context. To prevent this issue ,I opened a separate thread for calling CQRS commands then I could be able to call CQRS command successfully.

What is a Fan-out/fan-in pattern?
In the fan-out/fan-in pattern, we execute multiple functions in parallel and then wait for all functions to finish. Often, some aggregation work is done on the results that are returned from the functions.

![image](https://user-images.githubusercontent.com/2088948/200897252-70f90888-5889-4c3a-8cb8-fe3e89dd23b6.png)
