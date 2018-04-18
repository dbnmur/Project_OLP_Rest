# Java Course Rules

## Rules 

- [Set course name](#set-course-name)
- [Get course name](#get-course-name)
- [Show excersices](#show-excersices)
  - [Select `Hello World`](#select-hello-world)


## Regex
### Set course name
```Regex("(course name is|course is) (now )?(.*)")```
### Usage 
 ```Course name is PHP```
***
### Get course name
 ```Regex("(what course name|(what is|say) course name)")```
### Usage 
 ```What is course name```
***

### Show excersices
```Regex("(show me java|( tasks|exercises) )")```
### Usage 
```show me java tasks```, ```show me java exercises```
***

### Get task
```Regex("give (me task|task)")```
### Usage
```give me task```, ```give task```
***

### Learning material
```Regex("(suggest me java|( learning sites|studies sites) )")```
### Usage
```suggest me java learning sites```
***

### Java fact 
```Regex("tell|show|(me|(interesting fact| fact)|about java)tell|show|(me|(interesting fact| fact)|about java)")```
### Usage
```tell interesting fact about java```
***

