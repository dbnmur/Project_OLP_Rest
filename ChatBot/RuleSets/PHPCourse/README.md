# PHP Course Rules

## Rules 

- [Set course name](#set-course-name)
- [Get course name](#get-course-name)
- [Show excersices](#show-excersices)
  - [Select `Hello World`](#select-hello-world)
  - [Select `Baby steps`](#select-baby-steps)
  - [Select `My first IO`](#select-my-first-io)
  - [Select `Filter ls`](#select-filter-ls)
  - [Select `Concerned about separation`](#select-concerned-about-separation)
  - [Select `Array We Go`](#select-array-we-go)
  - [Select `Exceptional coding`](#select-exceptional-coding)
  - [Select `Database Read`](#select-database-read)
  - [Select `Time server`](#select-time-server)
  - [Select `HTTP JSON API`](#select-http-json-api)
  - [Select `Dependency Heaven`](#select-dependency-heaven)
- Show hints
    - [Get `Hello World` hint](#hello-world-hint)
    - [Get `Baby steps` hint](#baby-steps-hint)
    - [Get `My first IO` hint](#my-first-io-hint)
    - [Get `Filter ls` hint](#filter-ls-hint)
    - [Get `Concerned about separation` hint](#concerned-about-separation-hint)
    - [Get `Array We Go` hint](#array-we-go-hint)
    - [Get `Exceptional coding` hint](#exceptional-coding-hint)
    - [Get `Database Read` hint](#database-read-hint)
    - [Get `Time server` hint](#time-server-hint)
    - [Get `HTTP JSON API` hint](#http-json-api-hint)
    - [Get `Dependency Heaven` hint](#dependency-heaven-hint)

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
```Regex("(show excersices|(teach me|give me tasks) php)")```
### Usage 
```teach me php```
***
### Select `Hello World`
```Regex("(hello world|(give me hello world|hw) task)")```
### Usage 
```hello world```,
```give me hello world task```,
```hw task```
***

### `Hello World` hint
```Regex("(hello world hint|(give me hello world|hw) hint)")```
### Usage 
```hello world hint```,
```give me hello world hint```,
```hw hint```
***

### Select `Baby steps`
```Regex("(baby-steps|baby steps|(give me baby steps|bs|give me baby-steps) task)")```
### Usage 
```baby-steps```, ```baby steps```
***

### `Baby steps` hint
```Regex("(baby-steps hint|baby steps hint|(give me baby steps|bs|give me baby-steps) hint)")```
### Usage 
```baby-steps hint```, ```baby steps hint```
***

### Select `My first IO`
```Regex("(my-first-io|my first io|(give me my first io|mfio|give me my-first-io) task)")```
### Usage 
```my-first-io```, ```mfio task```
***

### `My first IO` hint
```Regex("(my-first-io hint|my first io hint|(give me my first io|mfio|give me my-first-io) hint)")```
### Usage 
```my-first-io hint```, ```mfio hint```
***

### Select `Filter ls`
```Regex("(filter-ls|filter ls|(give me filter ls|fls|give me filter-ls) task)")```
### Usage 
```filter-ls```, ```fls task```
***

### `Filter ls` hint
```Regex("(filter-ls hint|filter ls hint|(give me filter ls|fls|give me filter-ls) hint)")```
### Usage 
```filter-ls hint```, ```fls hint```
***

### Select `Concerned about separation`
```Regex("(concerned-about-separation|concerned about separation|(give me concerned about separation|cas|give me concerned-about-separation) task)")```
### Usage 
```concerned-about-separation```, ```cas task```
***

### `Concerned about separation` hint
```Regex("(concernedconcerned-about-separation hint|concerned about separation hint|(give me concerned about separation|cas|give me concerned-about-separation) hint)")```
### Usage 
```concerned-about-separation hint```, ```cas hint```
***

### Select `Array We Go`
```Regex("(array-we-go|array we go|(give me array we go|awg|give me array-we-go) task)")```
### Usage 
```array we go```, ```awg task```
***

### `Array We Go` hint
```Regex("(array-we-go hint|array we go hint|(give me array we go|awg|give me array-we-go) hint)")```
### Usage 
```array we go hint```, ```awg hint```
***

### Select `Exceptional coding`
```Regex("(exceptional-coding|exceptional coding|(give me exceptional coding|ec|give me exceptional-coding) task)")```
### Usage 
```exceptional-coding```, ```ec task```
***

### `Exceptional coding` hint
```Regex("(exceptional-coding hint|exceptional coding hint|(give me exceptional coding|ec|give me exceptional-coding) hint)")```
### Usage 
```exceptional-coding hint```, ```ec hint```
***

### Select `Database Read`
```Regex("(database-read|database read|db read|db-read|(give me database read|dbr|give me database-read) task)")```
### Usage 
```database-read```, ```dbr task```
***

### `Database Read` hint
```Regex("(database-read hint|database read hint|db read hint|db-read hint|(give me database read|dbr|give me database-read) hint)")```
### Usage 
```database-read hint```, ```dbr hint```
***

### Select `Time server`
```Regex("(time-server|time server|(give me time server|ts|give me time-server) task)")```
### Usage 
```time-server```, ```ts task```
***

### `Time server` hint
```Regex("(time-server hint|time server hint|(give me time server|ts|give me time-server) hint)")```
### Usage 
```time-server hint```, ```ts hint```
***

### Select `HTTP JSON API`
```Regex("(http-json-api|http json api|(give me http json api|hja|give me http-json-api) task)")```
### Usage 
```http-json-api```, ```hja task```
***

### `HTTP JSON API` hint
```Regex("(http-json-api hint|http json api hint|(give me http json api|hja|give me http-json-api) hint)")```
### Usage 
```http-json-api hint```, ```hja hint```
***

### Select `Dependency Heaven`
```Regex("(dependency-heaven|dependency heaven|(give me dependency heaven|dh|give me dependency-heaven) task)")```
### Usage 
```dependency-heaven```, ```dh task```
***

### `Dependency Heaven` hint
```Regex("(dependency-heaven hint|dependency heaven hint|(give me dependency heaven|dh|give me dependency-heaven) hint)")```
### Usage 
```dependency-heaven hint```, ```dh hint```
***
