# Provi Challenge
## Introduction
I know that it is a long shot to have you all review this after I didn't fully complete my submission in Hacker Rank but I hope the persistence is noted.

After my time was up, I created this console app for the first question to show you that I know how to do it. The biggest hurdles were converting the JSON response unto an C# object. After a while, I realized that I made simple mistake: I was trying to convert the response into a list when it actually was just a single object. Figuring this out was the bulk of my issue along with minor issues that I ran into along the way but they aren't worth mentioning.

## Instructions to Run App
1. Go to [this site](https://example.com) and download the .NET SDK. I used .NET Core 3.1 but you should be able to use .NET Core 5. [This video](https://www.youtube.com/watch?v=CDuUQNU7hWM) is a good resource to learn how if you prefer a walk-through video. To check if it worked, go inside your terminal and type `dotnet --version`. You should see the version installed if it worked.
2. Now to download my app. [Go here](https://github.com/athomas-wtv/park-bot) and clone my project.
3. Navigate into the file and type `dotnet build` then `dotnet run`. The app should be running an is ready for input. The only input that it will take are integers. If you try anything else, it'll ask you to try again.

### Disclaimer
There are a few c# best practices that I skipped out on for the sake of time so please overlook them.

### Video
I recorded myself writing this code so if you would like to view it for integrity sake then let me know. I'll add it to a Google Drive and share it with you.