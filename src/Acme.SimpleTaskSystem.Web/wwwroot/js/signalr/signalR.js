
const connection = new signalR.HubConnectionBuilder().withUrl("/taskHub").build();

connection.start().then(function () {
    console.log("Connected to signalR");
});
connection.on("UpdateTask", function (taskDetails) {
    console.log("On TaskUpdated");
    updateTaskDetails(taskDetails);
});

function updateTaskDetails(taskDetails) {
    console.log("Update task details");
    document.getElementById('title').textContent = taskDetails.Title;
    document.getElementById('desc').textContent = taskDetails.Description;

}