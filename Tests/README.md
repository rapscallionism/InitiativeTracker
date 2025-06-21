# Tests

## Getting Started

Requirements:
- Python (3.13 or greater)
- Docker Engine/Desktop

## Running Tests

To run the tests, you can simply run it through the CLI via the following command:

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