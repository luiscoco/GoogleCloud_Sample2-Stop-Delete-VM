using Google.Api;
using Google.Cloud.Compute.V1;

// TODO(developer): Set your own default values for these parameters or pass different values when calling this method.
string projectId = "focus-cache-387205";
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
