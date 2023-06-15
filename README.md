# GoogleCloud_Sample2-Stop-Delete-VM
https://cloud.google.com/compute/docs/samples/compute-instances-delete

This code demonstrates how to use the Google Cloud Compute API to stop and delete a virtual machine (VM) instance in a specified project and zone.

Let's go through the code step by step:

1. The code includes the necessary namespaces for interacting with the Google Cloud Compute API.
2. It defines the default values for three parameters: projectId, zone, and machineName. You can modify these values to match your specific project, zone, and machine name.
3. The code creates an instance of the InstancesClient class by calling the CreateAsync method. This client will be used to send requests to the Compute API.
4. The code prepares a StopInstanceRequest object, specifying the projectId, zone, and machineName of the VM instance to stop.
5. It calls the StopAsync method on the client object, passing in the stopRequest to stop the VM instance.
6. The code proceeds to delete the VM instance by calling the DeleteAsync method on the client object, passing in the projectId, zone, and machineName as parameters. The method returns an Operation object representing the asynchronous deletion operation.
7. After initiating the deletion, the code waits for the deletion operation to complete by calling the PollUntilCompletedAsync method on the instanceDeletion object.

In summary, this code stops a VM instance, and then deletes it using the Google Cloud Compute API. It showcases the basic workflow for interacting with VM instances using the API.

## Code

```csharp
using Google.Api;
using Google.Cloud.Compute.V1;

// TODO(developer): Set your own default values for these parameters or pass different values when calling this method.
string projectId = "XXXXXXXXXXXXXX";
string zone = "europe-southwest1-a";
string machineName = "luis-test-machine";

// Initialize client that will be used to send requests. This client only needs to be created
// once, and can be reused for multiple requests.
InstancesClient client = await InstancesClient.CreateAsync();

// Stop the VM instance before deleting it.
var stopRequest = new StopInstanceRequest
{
    Project = projectId,
    Zone = zone,
    Instance = machineName
};

await client.StopAsync(stopRequest);

// Start the VM instance before deleting it.
//var startRequest = new StartInstanceRequest
//{
//    Project = projectId,
//    Zone = zone,
//    Instance = machineName
//};

//await client.StartAsync(startRequest);

// Make the request to delete a VM instance.
var instanceDeletion = await client.DeleteAsync(projectId, zone, machineName);

//Wait for the operation to complete using client-side polling.
await instanceDeletion.PollUntilCompletedAsync();
```

