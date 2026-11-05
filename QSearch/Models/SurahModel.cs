using System;
using System.Collections.ObjectModel;

namespace QSearch;

public class SurahModel
{
 public ObservableCollection<ReciteSurah> Items { get; } = new();

    private readonly List<ReciteSurah> _allItems;
    private int _currentIndex;
    /// <summary>
    /// 10 verses per page
    /// </summary>
    private const int PageSize = 1;

    public bool IsBusy { get; set; }

    public SurahModel(List<ReciteSurah> allItems)
    {
        _allItems = allItems;
        _currentIndex = 0;
        LoadNextPage();
    }

    public async Task LoadMoreItemsAsync()
    {
        if (IsBusy || _currentIndex >= _allItems.Count)
            return;

        IsBusy = true;

        try
        {
            await Task.Run(LoadNextPage);
        }
        finally
        {
            IsBusy = false;
        }
    }

    private void LoadNextPage()
    {
        var page = _allItems
            .Skip(_currentIndex)
            .Take(PageSize)
            .ToList();

        MainThread.BeginInvokeOnMainThread(() =>
        {
            foreach (var item in page)
                Items.Add(item);

            _currentIndex += page.Count;
        });
    }
}
