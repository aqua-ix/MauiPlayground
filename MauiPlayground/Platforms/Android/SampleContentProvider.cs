using Android.Content;
using Android.Database;
using Uri = Android.Net.Uri;

namespace MauiPlayground;

[ContentProvider(["com.companyname.mauiplayground.provider"], Exported = true)]
public class SampleContentProvider : ContentProvider
{
    public override int Delete(Uri uri, string? selection, string[]? selectionArgs)
    {
        Console.WriteLine($"[SampleContentProvider] Delete: {uri}");
        return 0;
    }

    public override string? GetType(Uri uri)
    {
        Console.WriteLine($"[SampleContentProvider] GetType: {uri}");
        return null;
    }

    public override Uri? Insert(Uri uri, ContentValues? values)
    {
        Console.WriteLine($"[SampleContentProvider] Insert: {uri}");
        return null;
    }

    public override bool OnCreate()
    {
        Console.WriteLine("[SampleContentProvider] OnCreate");
        return true;
    }

    public override ICursor? Query(Uri uri, string[]? projection, string? selection, string[]? selectionArgs, string? sortOrder)
    {
        Console.WriteLine($"[SampleContentProvider] Query: {uri}");
        return null;
    }

    public override int Update(Uri uri, ContentValues? values, string? selection, string[]? selectionArgs)
    {
        Console.WriteLine($"[SampleContentProvider] Update: {uri}");
        return 0;
    }
}