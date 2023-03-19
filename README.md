Instructions:

Open the solution (.sln) file in Visual Studio 2022. 

Press the run button and a page should automatically open in your default browser.

Each of the options on the page can be clicked on to test their functionality.



Integration test:

(at any point during this test, you can use the PrintEvent, PrintMeeting, PrintUser and PrintListOfEverything buttons to convince yourself the expected behaviour is occurring)

Using the CreateUser button, create three users with Ids 1, 2, 3; use a name of your choice for the organisation field

Using the CreateEvent button, create an event with Id 1 and type "1 2 3" in the IdsOfAttendingUsers field.

Using the CreateMeeting button, create a meeting with 1 as IdOfUserStartingMeeting, 1 as MeetingId, 1970-1-1 as StartTime and EndTime, and "2 3" as IdsOfInvitedUsers.

Use the AcceptInvitation button with 2 as UserId, and 1 as MeetingId.

Use the RejectInvitation button with 3 as UserId, and 1 as MeetingId.
