# Running the application

Navigate to the root directory of the project and run the following: 

`docker build --no-cache -t <image-name>:<tag> .`

You can use whatever name for the `<image-name>:<tag>` as long as it is consistent.

Once it finishes bulding, run the following:

`docker run -v dpkeys:/var/dpkeys -p 8080:8080 <image-name>:<tag>`