Conditional Manifest
========================

This is a File -> New Xamarin Studio Android project to reproduce behavior I see and don't expect when trying to conditionally overwrite the AndroidManifest project property.

###Abstract
My goal is to add a Conditional statement to the csproj file such that when the Build configuration is set to *Debug*, my Android app will use `Properties\AndroidManifestDebug.xml` as the manifest template, and use `Properties\AndroidManifestDebug.xml` for all other Build configurations. 

More specifically, I want to define separate manifest templates for Build configurations so that I can build and deploy versions of the same app with different package names side-by-side:

    Debug: com.example.conditionalmanifest.debug
    Release: com.example.conditionalmanifest

The behavior that I expect is that when I **redefine** the AndroidManifest property, that the build process will use the redefined AndroidManifest file to build the application package.

The behavior that I see is that when I redefine the AndroidManifest inside of the existing *Debug* conditional `PropertyGroup` and attempt to deploy a Debug build, the application deployment fails:

    Deployment failed because of an internal error: Could not find file "/repro/ConditionalManifest/bin/Debug/com.example.conditionalmanifest-Signed.apk".
    
    Deployment failed. Internal error.

