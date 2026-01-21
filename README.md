# 🐼 PandaTranslator

A powerful and efficient localization system for Unity that supports text, audio, and image translations with automatic synchronization and runtime performance optimization.

## ✨ Features

- **Multi-format Support**: Translate text, audio clips, and images/sprites
- **Automatic Synchronization**: Keys and categories stay in sync across all languages
- **Performance Optimized**: Dictionary-based runtime switching with smart reference caching
- **User-Friendly Editor**: Comprehensive Window Editor for all localization management
- **One-Click Language Setup**: Create new languages instantly with full automation
- **Smart References**: LocalizedVariable maintains object references during language changes
- **No Manual SO Editing**: Everything is handled through the editor interface

## 📋 Requirements

- Unity 2020.3 or higher (adjust based on your actual requirement)
- TextMeshPro (if using text localization)

## 🚀 Quick Start

### Installation

1. Import PandaTranslator package into your Unity project
2. Open the Language Editor via `Mimi Games > Language Editor`

### Creating Your First Language

1. In the Language Editor window, click **"Create New Language"**
2. Enter language name (e.g., "English", "Polish")
3. The system automatically creates all necessary ScriptableObjects

### Adding Translations

1. In the Language Editor, select your category or create a new one
2. Add translation keys with their values:
    - **Text**: Enter translated strings
    - **Audio**: Assign audio clips
    - **Images**: Assign sprites or textures

### Using Translations in Code

```csharp
// Setup LanguageManager (create singleton or use DI)
// Then access localized content:

// Text localization
LanguageItem greeting = languageManager.GetLanguageItem("ui/greeting");
myText.text = greeting.translation; // "Hello" or "Cześć" depending on current language

// Audio localization
LanguageItem sound = languageManager.GetLanguageItem("sfx/button_click");
audioSource.clip = sound.audioClip;

// Image localization
LanguageIte icon = languageManager.GetLocalizedImage("flags/country");
image.sprite = icon.sprite;
```

### Using Translations in Inspector

1. Add `LanguageSwitcher` component to your scene for runtime language switching
2. Use LocalizedVariable components directly on GameObjects for automatic updates:
    - `LocalizedText` - automatically updates TextMeshPro/Text components
    - `LocalizedImage` - automatically updates Image/SpriteRenderer components
    - `LocalizedAudioSource` - automatically updates AudioSource clips

### Switching Languages

```csharp
// Via code
languageManager.SetLanguage(SystemLanguage.Polish);
```

## 🎯 Key Concepts

### LocalizedVariable
The core data structure that holds localized content. When you switch languages, the **reference stays the same** but the internal values updates automatically. This means:
- No need to re-fetch references after language changes
- Automatic UI updates if components are properly bound
- Minimal garbage collection overhead

### Category & Key Synchronization
All languages share the same structure of categories and keys. When you add a key in one language, it automatically appears in all others (with empty values to fill). This prevents the common issue of mismatched translation structures.

### Dictionary-Based Runtime
On language switch, PandaTranslator rebuilds an internal dictionary for O(1) lookup performance instead of searching through lists. This makes language switching instant even with thousands of translations.

## 📖 Documentation

For detailed documentation, see:
- [Full Documentation](Documentation/PandaTranslator.md) - Complete API reference and advanced features
- [CHANGELOG.md](CHANGELOG.md) - Version history and updates

## ⚠️ Important Notes

- **Never manually edit ScriptableObjects** - always use the Language Editor window
- All category and key operations are automatically synchronized across languages
- The LanguageManager should be initialized before accessing any localized content

## 📄 License

MIT License

## 🐛 Known Issues

None currently. See [CHANGELOG.md](CHANGELOG.md) for fixed issues from previous versions.

## 💡 Tips

- Organize keys hierarchically: `Menu.title`, `Menu.subtitle`, `Button.click`
- Keep category names short and descriptive: `Menu`, `Dialogue`, `SFX`, `Items`
- Use the Window Editor's search functionality for large projects
- Consider implementing a fallback language for missing translations

---

Made with 🐼 by thief01 @ Mimi Games