# Async Learning

[Read the Docs](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/async/)

## Threading

1. IO

	- Networking
	- Databases

2. Windows Forms / UI

	- FormsApp, Background service
	
3. Multithreading, Hard way

	- Atomic Operation
	- keyword : Lock 
	- Thread Pooling, Run on a background thread, begin / end pattern
	- Signaling, a token

4. Tasks

	- A Promise of work happening Async
	- some benefits include...
		- Auto-Tuning the ThreadPool
		- not needing to handle the pool or start threads
		- more control (Status, return values, cancellation, exception handling, custom scheduling, and continuation)
	- Explicit use of class Task, and Task<TResult>
	- Taskfactory
	- <object>.OperationAsync, new pattern

5. Async Await

	- dosn't use a new thread
	- use Task.Run to utilize a new thread

	- async 
		- for methods returning (void, Task or Task<T>)
	- await
		- the compiler does the hard work of splitting up this task
		- Point of possible suspension / resumption
		- No need to invoke .Start()

Error Handling

	- Exceptions
	- Aggregate Exception and .Flatten
	- New in C#6.0 await in catch and finally
	- Using Tasks can help with handling exceptions
	- Async void can be difficult to handle


### What is dangerous about threading?

- Shared and / or mutable state
	- two different threads trying to do the same task or memory
- resulting locks and deadlocks, when using a resource to use exclusive access to something
- seek out patterns and models to avoid deadlocks
- "Thread Safe" data types can help
- Some Types are not thread safe, check Documentation

