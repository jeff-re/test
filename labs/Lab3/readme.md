# Character Roster (ITSE 1430)

## Version 1.0

In this lab you will extend your existing character creator program to better use the features available in .NET including generic lists, interfaces and validation.

*Note: This program will not actually send any emails. We are going to simulate that functionality.*

## Skills Needed

- C# 
  - Abstract Classes
  - Extension Methods
  - Generic Types
  - Interfaces
  - Lists
- Windows Forms
  - Child Forms
  - Layouts
  - List Controls
  - Validation

## Story 1 - Add a Character Roster Interface
 
Add an interface called `ICharacterRoster` to manage the list of characters.

### Description

In the business library create an interface to represent the roster of characters. The interface should have the appropriate methods for handling the functionality defined below.

To simplify the logic you will need to update the existing `Character` class to have a unique identifier. It is recommended that you use a simple integral value that is greater than 0. The identifier will be managed by the roster implementation.

#### Add

Adds a character to the roster. This method is responsible for adding the character to the roster and returning a unique identifier for the character.

*Note: The roster is responsible for the identifier. Do not attempt to manage it outside the roster implementation.* 

Parameters:
- The character to add.

Returns:
- The newly added character with a unique identifier.

Error Conditions:
- The character is invalid.
- A character with the same name already exists.

#### Delete

Removes a character from the roster.

Parameters:
- The identifier of the character.

Returns: None.

Error Conditions: 
- The identifier is out of range (less than or equal to 0). It IS NOT an error if the character does not exist.

#### Get

Gets a specific character from the roster.

Parameters:
- The identifier of the character.

Returns:
- The immutable character if found or `null` otherwise.

Error Conditions:
- The identifier is out of range (less than or equal to 0). It IS NOT an error if the character does not exist.

#### Get All

Gets all the characters in the roster. 

Parameters: None.

Returns:
- The immutable list of characters. Changes to the returned list of characters should not impact the original roster.

#### Update

Updates an existing character in the roster.

Parameters:
- The identifier of the character to update.
- The new character information.

Error Conditions:

- The updated character is invalid.
- The existing character cannot be found or is invalid.
- The character's name is changed AND another character with the same name already exists.

### Acceptance Criteria

1. The interface is properly defined.
1. The interface is properly documented.

## Story 2 - Create a Roster Stored in Memory

Create a roster for the interface defined earlier using a collection.

### Description

Implement the interface from Story 1 using an in-memory collection. Keep in mind a few guidelines.

1. Characters returned from the roster should be different from those stored in the roster so that changes to the returned data do not change the data in the roster unless the `Update` method is called.
1. The roster is responsible for managing the unique identifiers. Use a static field to track the last identifier and increment it each time a new character is added. 
1. Identifiers should not change once created for a character.

### Acceptance Criteria

- All the interface methods behave as defined by the interface.
- Making changes to data returned from the roster do not change the underlying roster data.
- Ensure type(s) are properly documented.

## Story 3 - Update UI to Use Interface

Update the UI to use the interface.

### Description

- Replace the existing roster field in the UI with the interface.
- Update the existing code to use the methods in the interface. 
- Create an instance of the memory roster to use in the UI.

### Acceptance Criteria

- Array logic replaced with interface calls.
- Only reference to the memory implementation is the `new` operator.
- All functionality continues to work correctly.

## Story 4 - Implement Character Validation

Implement the `IValidatableObject` interface on the character class.

### Description

- Implement the `IValidatableObject` interface on the `Character` class.
- Modify the add and update logic in the memory roster to validate the character using the `IValidableObject` interface.
- Update the UI to validate the character using the `IValidableObject` interface before attempting to add or save the character.

### Acceptance Crieria

- Interface is properly implemented with all existing rules related to a single character.
- UI correctly calls interface to validate character.
- Roster correctly calls interface to validate character.
- Form does not close if any validation errors occur.

## Story 5 - Implement Error Provider in UI

Add support for `ErrorProvider` in the UI.

### Description

- Add the `ErrorProvider` to the UI.
- Configure the provider to validate each field as needed.
- Ensure the validation is triggered when editing an existing character.

### Acceptance Criteria

- Ensure that errors are properly shown using the provider for field-level validation.
- Form does not close if any validation errors occur.

## Requirements

- DO ensure code compiles cleanly without warnings or errors (unless otherwise specified).
- DO ensure all acceptance criteria are met.
- DO Ensure each file has a file header indicating the course, your name and date.
- DO ensure you are using the provided `.gitignore` file in your repository.
- DO ensure the entire solution directory is uploaded to Github (except those files excluded by `.gitignore`).
- DO submit your lab in MyTCC by providing the link to the Github repository.
