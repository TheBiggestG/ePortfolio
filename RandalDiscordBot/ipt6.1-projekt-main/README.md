# Project Work IPT6.1

### Randall, a Discord Bot by Nicola Truscello and Russell Stansfield

![Alt text](./DiscordLogo.png "Discord")

## Table of Contents

1. [Project Idea](#project-idea)
2. [Project Description](#project-description)
3. [Architecture and Design](#architecture-and-design)
4. [Prototyping](#prototyping)
5. [Implementation](#implementation)
6. [Testing](#testing)
7. [Project Presentation](#project-presentation)
8. [Conclusion](#conclusion)

---

## Project Idea

We had already programmed a Discord bot in a previous module. Discord is similar to a chatroom where users communicate with each other on a server. These chatrooms need to be moderated accordingly. We wanted to recreate the bot from scratch, but this time better and with enhanced features. This time, the bot tracks all activities and logs them, allowing it to escalate punishments appropriately.

## Project Description

Our project is to program a Discord bot that warns Discord users when they use banned words. These words are stored in a JSON file. Additionally, through the web app, users can manually ban, kick, mute, and warn other users by entering the chosen user. It is also possible to search for users and their logs. All data and violations by users are stored in a database, allowing the bot to take corresponding actions and apply appropriate punishments.

## Architecture and Design

We wanted to split the program into two parts because, due to Blazor's architecture, we had to distribute the frontend and backend across two servers. These parts needed to be linked together through API requests. This issue was also present in our previous Discord bot project.

## Prototyping

### Randallbot Backend Prototype

Russell created a simple prototype where the bot could only respond automatically. It could mute users by assigning them a role that removed their speaking privileges. If a user said a banned word, they were muted. This was tested with a Discord account named "ScaryGonzalesGamer234" by saying banned words. This account was successfully muted. If a bot said something, it was simply ignored by Randall. We tested this with an existing bot called Carl-Bot, which said something after our command. Randall simply ignored it.

### RandallbotDB Prototype

Nicola programmed a simple version of the current database. This included a database connection and basic CRUD operations such as reading all tables and inserting into all tables, along with the corresponding classes, made possible with Entity Framework.

## Implementation

The implementation of the project was difficult, even though we already had prototypes. Many issues arose with the Discord bot, as we were working with a difficult-to-learn API. In the frontend, there were only solvable issues with Blazor. The most problems occurred with linking the parts, as we had to solve this through API requests. Since we had resolved this last time, we underestimated it and were unfortunately unable to complete the project. At least there were no problems with the database.

### Backend Issues:

- Problems with the API token, as it sometimes changed or disappeared.
- Problems with muting multiple users simultaneously.
- Problems with setting the bot's permissions.
- Problems with banning and kicking due to permissions and API issues.

## Testing

Unfortunately, we were unable to get the entire project running, as the frontend, backend, and database could not be linked together. However, we were able to test the programs individually. For the database, we used unit tests, and for the backend, we performed manual tests with existing Discord bots and Discord accounts to test the automated functions.

## Project Presentation

The link to the project presentation can be found in the "Documentation" folder.

## Conclusion

### Successes

- **Improved Functionality:** Compared to our previous Discord bot, we implemented significantly enhanced features, including automatic and manual user management through warnings, bans, kicks, and mutes.
- **Stable Database:** Thanks to Nicola, we had a database with various CRUD operations and a database connection.

### Challenges

- **API Complexity:** Working with the Discord API was a major challenge, especially when dealing with API tokens and permissions management. However, we gained valuable experience in working with API-based applications.
- **Simultaneous User Actions:** Managing actions for multiple users simultaneously, such as muting or banning, was more complex than expected. This required additional measures for synchronization and error handling.
- **Frontend Issues:** Although most issues in the frontend were solvable, they still required significant effort.
- **API Linking Between Projects:** We had already encountered problems with API linking in the last Discord bot project, and this time it happened again. We underestimated it, and it required much more effort. As a result, we were unable to complete the project.

### Outlook

For future projects, we have suggested the following goals and improvements:

- Less dependency on Blazor.
- Better planning and setting goals for each week.
- Considering refreshers and other factors during planning.

In conclusion, Randall was a challenge to program, especially in the backend where we had to work with the Discord.net API and link the database, frontend, and backend through API requests. However, the database worked well, and there were only a few solvable problems in the frontend.
