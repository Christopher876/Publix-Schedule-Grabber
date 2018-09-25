# Publix-Schedule-Grabber
A very simple program that runs and grabs the next week's schedule and adds it to your Google Calendar.
<br>
I wrote this in about a few hours (probably overexaggerating) before I had actually learnt thoroughly about using the Webclient so this program is based off of selenium. So the code yes is not very optimized and it has many useless variables in it as well. I did not really go back in to fix them because it performed as I would have liked. Plus I would probably rewrite a bunch of it using my knowledge of the webclient now.
<br>
For some reason on the Mobile website the schedule times are stored in the html code when loaded up compared to the desktop website that does not. This program just parses that html file and then uses a few Stringbuilders and combines them to form a the scheduled times and then uploads them to the Google Calendar.
