# Greetings Rules

## Rules 
- [Get feeling](#get-feeling)
- [Repeat last sentence](#repeat-last-sentence)
- [Repeat sentence](#repeat-sentence)
- [Get Bot name](#get-bot-name)
- [Set username](#set-username)
- [Get username](#get-username)
- [Greet](#greet)
- [Default](#default)


## Regex

### Get feeling
```Regex("how (are you|do you feel)")```
### Usage 
 ```how are you```
***

### Repeat last sentence
```Regex("(please )?repeat the last sentence"```
### Usage
```please repeat the last sentence```
***

### Repeat sentence
```Regex("(please )?repeat(?<sentence> .*)")```
### Usage
```please repeat sentence text ```
***

### Get Bot name
```Regex("(who are you|(what is|say) your name)")```
### Usage 
```who are you```
***

### Set Username
```Regex("my name is (now )?(.*)")```
### Usage
``` My name is Terminator```
***

### Get Username 
```Regex("(what is|say) my name")```
### Usage 
```say my name```
***

### Greet
```Regex("(hi|hello|labas|sveikas)")```
### Usage
```hi```
***

### Default
```Regex(".*")```
### Usage
```some random text which bot does not recognise```