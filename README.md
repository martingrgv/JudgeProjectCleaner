# Judge Project Cleaner
### This app archives your project to .zip file.
By default excludes: bin, obj, datasets and migrations entries for SoftUni's judge system submits.
- Paste your directory's full path where .csproj file is located and it will do the job for you :)
- The project will be archived in project's folder in `<project-name>Cleaned.zip` file
- Alternatively for bash terminal fans you can create executable yourself
  
<hr/>
Example input: `C:\Users\pcuser\source\repos\martingrgv\MyProject` 
<hr/>

### Creating terminal command from console app (UNIX)
Creating terminal command is simple.
1. Publish as self contained application <br/>
`dotnet publish -c Release --self-contained=true /p:PublishSingleFile=true`
2. Copy the executable <br/>
`sudo cp JudgeProjectCleaner/bin/Release/JudgeProjectCleaner /usr/loca/bin`
- Alternatively you can reaname the command. In my case I renamed it to `judgecleaner`
3. Make executable `sudo chmod +x /usr/local/bin/judgecleaner`

### !Adjust parameters accourdingly

Example execution: `judgecleaner -p C:\Users\pcuser\source\repos\martingrgv\MyProject`
<br/>

## What to expect?
- Documentation
- Unit tests
- More args options
- Help option for terminal use
