# Async Learning


## Threading

1. IO

	- Networking
	- Databases

2. Windows Forms / UI

	- FormsApp, Background service
	
3. Multithreading, Hard way

	- Atomic Operation
	- keyword : Lock 

### What is dangerous about threading?

- Shared and / or mutable state
	- two different threads trying to do the same task or memory
- resulting locks and deadlocks, when using a resource to use exclusive access to something
- seek out patterns and models to avoid deadlocks
- "Thread Safe" data types can help
- Some Types are not thread safe, check Documentation

