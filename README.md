[![Total Downloads](https://img.shields.io/nuget/dt/Meowtrix.UniversalClassLibrary.svg)](http://www.nuget.org/packages/Meowtrix.UniversalClassLibrary/)
[![Latest Stable Version](https://img.shields.io/nuget/v/Meowtrix.UniversalClassLibrary.svg)](http://www.nuget.org/packages/Meowtrix.UniversalClassLibrary/)

# UniversalClassLibrary

Class library for all .NET platforms.

## Purpose

Provides some classes and helpers that can be used in all .NET platforms.

Because .NETFramework provides BCL with the framework, while other platforms only provide runtime, it's necessary to specify net46 as a explicit supported platform.

## Download

UniversalClassLibrary is available as a [NuGet package](http://www.nuget.org/packages/Meowtrix.UniversalClassLibrary/) through nuget.org with the package ID [`Meowtrix.UniversalClassLibrary`](http://www.nuget.org/packages/Meowtrix.UniversalClassLibrary/).

## Components

### ITask

An interface wrapper for Task Parallel Library, provides covariance. See [Threading/ITask](https://github.com/Meowtrix/UniversalClassLibrary/tree/master/Meowtrix.UniversalClassLibrary/Threading/ITask).

### Linq

Additional methods for `System.Linq`.

### ComponentModel.NotificationObject

A base class that implements `System.ComponentModel.INotifyPropertyChanged`.