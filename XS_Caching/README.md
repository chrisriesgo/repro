Hello World - XS_Caching
========================

This is a super simple hello world application. It uses a TextView to
display a plain old hello world message via a string resource.

In order to test that `Resources/values/strings.xml` is being cached, 
I'm copying a new `strings.xml` file over the one in the Android project 
via a BeforeBuild Target Copy command from the `_Build` project. 

The unexpected behavior you will notice is the app will read _Hello World, HelloAndroid!_ instead of the expected _Hello World, HelloXS_Caching!_. My expectation is that the file from the `_Build` project should overwrite the Android resource, and be pulled into the app during the build process. It, however, isn't.