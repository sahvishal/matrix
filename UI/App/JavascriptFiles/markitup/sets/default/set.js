// ----------------------------------------------------------------------------
// markItUp!
// ----------------------------------------------------------------------------
// Copyright (C) 2011 Jay Salvat
// http://markitup.jaysalvat.com/
// ----------------------------------------------------------------------------
// Html tags
// http://en.wikipedia.org/wiki/html
// ----------------------------------------------------------------------------
// Basic set. Feel free to add more tags
// ----------------------------------------------------------------------------
var mySettings = {
	onShiftEnter:  	{keepDefault:false, replaceWith:'<br />\n'},
	onCtrlEnter:  	{keepDefault:false, openWith:'\n<p>', closeWith:'</p>'},
	onTab:    		{keepDefault:false, replaceWith:'    '},
	markupSet: [
        { name: 'Heading 1', key: '1', openWith: '== ', closeWith: ' ==', placeHolder: 'Your title here...' },
        { name: 'Heading 2', key: '2', openWith: '=== ', closeWith: ' ===', placeHolder: 'Your title here...' },
        { name: 'Heading 3', key: '3', openWith: '==== ', closeWith: ' ====', placeHolder: 'Your title here...' },
        { name: 'Heading 4', key: '4', openWith: '===== ', closeWith: ' =====', placeHolder: 'Your title here...' },
        { name: 'Heading 5', key: '5', openWith: '====== ', closeWith: ' ======', placeHolder: 'Your title here...' },
        { separator: '---------------' },
        { name: 'Bold', key: 'B', openWith: "'''", closeWith: "'''" },
        { name: 'Italic', key: 'I', openWith: "''", closeWith: "''" },
        { name: 'Stroke through', key: 'S', openWith: '<s>', closeWith: '</s>' },
        { separator: '---------------' },
        { name: 'Bulleted list', openWith: '(!(* |!|*)!)' },
        { name: 'Numeric list', openWith: '(!(# |!|#)!)' },
        { separator: '---------------' },
        { name: 'Picture', key: 'P', replaceWith: '[[Image:[![Url:!:http://]!]|[![name]!]]]' },
        { name: 'Link', key: 'L', openWith: '[[![Link]!] ', closeWith: ']', placeHolder: 'Your text to link here...' },
        { name: 'Url', openWith: '[[![Url:!:http://]!] ', closeWith: ']', placeHolder: 'Your text to link here...' },
        { separator: '---------------' },
        { name: 'Quotes', openWith: '(!(> |!|>)!)' },
        { name: 'Code', openWith: '(!(<source lang="[![Language:!:php]!]">|!|<pre>)!)', closeWith: '(!(</source>|!|</pre>)!)' },
        { separator: '---------------' },
        { name: 'Preview', call: 'preview', className: 'preview' }
    ]
}
