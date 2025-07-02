# Tests

## Getting Started

Requirements:
- Python (3.13 or greater)
- Docker Engine/Desktop

## Running Tests

To run the tests, you need to make sure that you have the project running in the associated docker containers. Please
refer to the [README to run the backend in Docker](../InitiativeTrackerBackend/README.md).

Once the backend is running in a docker container (with the database), you can simply run the tests
through the CLI via the following command:

```
pytest
```

## Managing Dependencies

Make sure to have the `pip-tools` package installed. This can be installed via the following command:

```
py -m pip install pip-tools
```

When installing a package, make sure to add it into the [Requirements.in File](./requirements.in) and then run
the following command:

```
pip-compile requirements.in
```

This should generate/regenerate the `requirements.txt` file to list out all the dependencies currently being used.