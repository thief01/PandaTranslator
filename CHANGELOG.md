# Changelog

All notable changes to Unity Localization System will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

---

## [2.0.0] - 2026-01-21

### Added
- **Automatic Category and Key Synchronization**: Categories and keys are now automatically synchronized between all languages, preventing translation mismatches
- **One-Click Language Creation**: New languages can now be created via a dedicated button that fully automates the setup process (no more context menu workflow)
- **Runtime Dictionary System**: Implemented dictionary-based language switching for significantly improved performance
- **Centralized Window Editor**: All localization management is now handled through a unified Window Editor interface
- **Smart Reference System**: LocalizedVariable (text/audio/image) now maintains the same object reference when language changes, with only the internal value being updated - eliminating the need to re-fetch references after language switching

### Changed
- Language creation workflow moved from context menu to Window Editor with automated setup
- Language switching now uses dictionary lookups instead of linear searches
- ScriptableObject manipulation is now handled entirely by the editor - users should no longer manually edit SOs

### Fixed
- **CRITICAL**: Fixed major bug where order of keys and categories could desynchronize between languages, causing incorrect translations to be displayed
- Translation data consistency issues resolved through synchronization system

### Removed
- Manual ScriptableObject editing workflow (replaced by Window Editor automation)
- Context menu-based language creation

### Technical Notes
- Synchronization currently uses string-based matching (future versions may implement ID-based system for additional robustness)
- Dictionary is rebuilt on language change to ensure data consistency

---

## [1.0.0] - [Initial Release Date]

### Added
- Language Editor for managing translations
- Support for text, audio, and image localization
- LocalizedVariable components for runtime translation
- Language Switcher component
- ScriptableObject-based translation storage
- Context menu-based language creation

### Known Issues
- Order of keys and categories can desynchronize between languages, causing translation errors (fixed in 2.0.0)